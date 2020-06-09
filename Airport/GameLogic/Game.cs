using Airport.GameLogicInterface;
using Airport.GameModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

using static Airport.GameLogic.GameConstants;

namespace Airport.GameLogic
{
    [Serializable]
    public sealed class Game: IGameLogicInteractable
    {
        #region Технические игровые параметры
        //Игровой таймер, имитирующий ход игрового времени
        [NonSerialized]
        private Timer gameTimer;

        //Генератор случайных чисел
        [NonSerialized]
        private Random randomizer;
        #endregion
        #region Игровые параметры
        //Игровые дата/время
        private DateTime currentGameDate;

        //Цена на топливо
        private decimal fuelPrice;

        
        #endregion
        #region Информация о рейсах и контрактах
        //Доска обхъявлений
        private BulletinBoard bulletinBoard;

        private ObservableCollection<Contract> observableContracts;
        //Набор подписанных контрактов, где ключом выступает
        //номер связанного рейса
        private Dictionary<uint, Contract> contracts;

        private List<PlaneFlight> planesProgress;
        #endregion
        #region Информация об игроке
        //Финансовое положение игрока
        private decimal currentSavings;

        private Dictionary<string, Plane> planes;

        //Имеющиеся у игрока самолёты
        private ObservableCollection<Plane> observablePlanes;

        //максимальный ID самолета
        private int MaxID;

        #endregion
        #region Игровая скорость
        //Текущая скорость игры
        private GameSpeeds currentGameSpeed;
        public GameSpeeds CurrentGameSpeed
        {
            get
            {
                return currentGameSpeed;
            }
            set
            {
                currentGameSpeed = value;
                bool wasRunnning = gameTimer.Enabled;
                gameTimer.Stop();
                switch (currentGameSpeed)
                {
                    //Обычная игровая скорость
                    case GameSpeeds.x1:
                        gameTimer.Interval = StartSpeed;
                        break;
                    //10-кратное ускорение
                    case GameSpeeds.x10:
                        gameTimer.Interval = StartSpeed / 10;
                        break;
                    //50-кратное ускорение
                    case GameSpeeds.x50:
                        gameTimer.Interval = StartSpeed / 50;
                        break;
                    //100-кратное ускорение
                    case GameSpeeds.x100:
                        gameTimer.Interval = StartSpeed / 1000;
                        break;
                }
                if (wasRunnning)
                    gameTimer.Start();
            }
        }
        #endregion
        #region Игровые события
        //Событие, происходящее при изменении финансов игрока
        public event EventHandler<decimal> SavingsChanged;

        //Событие, происходящее при изменении игровой даты
        public event EventHandler<DateTime> DateChanged;

        //Событие, происходящее при изменении цены на топливо
        public event EventHandler<decimal> FuelPriceChanged;

        public event EventHandler<FlightProgressEventArgs> FlightProgressChanged;

        //Событие, происходящее при проигрыше
        public event EventHandler GameOver;
        #endregion
        #region Информация о самолётах (местоположение, назначение и т.п.)
        //Местоположение самолётов игрока (соотношение ID самолёта/ID города)
        private Dictionary<string, City> planesAndCities;
        #endregion
        public Game()
        {
            randomizer = new Random();
            gameTimer = new Timer(StartSpeed);

            contracts = new Dictionary<uint, Contract>();
            planesAndCities = new Dictionary<string, City> { { "0", CitiesInfo.cities["1"] } };
            Plane firstPlane = new Plane("0", Plane.Models.TY_134, Plane.Owns.Bought);
            MaxID = 0;
            planes = new Dictionary<string, Plane> { { firstPlane.ID, firstPlane } };
            planesProgress = new List<PlaneFlight>();
            observablePlanes = new ObservableCollection<Plane> { firstPlane };
            observableContracts = new ObservableCollection<Contract>();
            currentGameDate = DateTime.Now;
            bulletinBoard = new BulletinBoard();
            UpdateBulletinBoard();
            SignContract(bulletinBoard.Flights.First().Number);
            gameTimer.AutoReset = true;
            gameTimer.Elapsed += Act;
        }
        #region Методы для получения информации о состоянии игрового мира
        //Метод для получения текущей игровой даты
        public DateTime GetCurrentDateTime()
        {
            return currentGameDate;
        }

        //Метод для получения цены на топливо
        public decimal GetFuelPrice()
        {
            return fuelPrice;
        }
        #endregion
        #region Методы для получения информации о состоянии дел игрока
        //Метод для получения списка имеющихся у игрока самолётов
        public ObservableCollection<Plane> GetPlanes()
        {
            return observablePlanes;
        }

        //Метод для получения информации о том, сколько у игрока денег
        public decimal GetSavings()
        {
            return currentSavings;
        }
        #endregion
        #region Методы для получения информации о самолетах (местоположение, назначение и т.п.) 
        //Метод для получения информации о местоположении всех самолётов
        public List<Tuple<string, City>> GetLocationsOfAllPlanes()
        {
            return planesAndCities.Keys.Select(key => Tuple.Create(key, planesAndCities[key])).ToList();
        }

        //Метод для получения информации о местоположении самолёта по его ID
        public City GetPlaneLocation(string ID)
        {
            City city;
            bool success = planesAndCities.TryGetValue(ID, out city);
            return success ? city : null;
        }
        #endregion
        #region Методы для работы с доской объявлений, рейсами и контрактами
        //Метод для получения списка имеющихся
        //на доске объявлений рейсов
        public ObservableCollection<Flight> GetFlightsInfo()
        {
            return bulletinBoard.Flights;
        }

        public ObservableCollection<Contract> GetContracts()
        {
            return observableContracts;
        }

        //Метод для подписания контракта на заданный рейс
        public void SignContract(uint flightNum)
        {
            Flight associatedFlight = bulletinBoard.GetFlight(flightNum);
            Contract signedContract = null;
            switch (associatedFlight.Regularity)
            {
                case 0:
                    signedContract = new Contract(associatedFlight);
                    break;
                default:
                    signedContract = new Contract(associatedFlight, bulletinBoard.GetRevertedFlight(associatedFlight));
                    break;
            }
            signedContract.Forfeit = randomizer.Next(100, 1000);
            foreach (Flight f in signedContract.ConnectedFlights)
                contracts.Add(f.Number, signedContract);
            observableContracts.Add(signedContract);
        }

        //Метод для отмены подписанного контракта
        public void CancelContract(uint flightNum)
        {
            if (!contracts.ContainsKey(flightNum))
                return;
            Contract cancelledContract = contracts[flightNum];
            if (cancelledContract.ConnectedFlights[0].Regularity == 0 || 
                cancelledContract.ConnectedFlights[0].Regularity > 0 && 
                cancelledContract.CountOfPerformedFlights == 0)
            {
                currentSavings -= cancelledContract.Forfeit;
                SavingsChanged?.Invoke(this, currentSavings);
            }
            observableContracts.Remove(contracts[flightNum]);
            contracts.Remove(flightNum);
        }

       
        //Метод для назначения самолёта на контракт
        public bool AssignPlaneToContract(string planeID, uint flightNum)
        {
            //Ищем связываемые самолёт и контракт
            Contract contract = contracts[flightNum];
            Plane assignedPlane = planes[planeID];

            //Назначаем проверку предлагаемого самолёта
            Predicate<Plane> predicate = null;
            switch (contract.ConnectedFlights[0].FlightType)
            {
                case FType.Freight:
                    predicate = plane => plane.MaxSeatings >= contract.ConnectedFlights[0].PasCount;
                    break;
                case FType.Passenger:
                    predicate = plane => plane.Payload >= contract.ConnectedFlights[0].Weight;
                    break;
            }

            if (!predicate(assignedPlane) 
                || assignedPlane.Range < CitiesInfo.GetRoute(contract.ConnectedFlights[0].IDFrom, 
                    contract.ConnectedFlights[0].IDTo).Distance)
                return false;


            contract.AssignedPlane = assignedPlane;
            return true;
        }

        public void ResetPlaneForContract(uint flightNum)
        {
            contracts[flightNum].AssignedPlane = null;
        }

        //Метод для назначения времени вылета в контракт
        public void SetTimeForContract(uint flightNum, TimeSpan time)
        {
            contracts[flightNum].Time = time;
        }

        //Метод для перебазирования самолёта (пустой перелёт в другой город)
        public decimal RebasePlane(string planeID, string destinationID)
        {
            return SendPlane(planeID, destinationID, null);
        }
        #endregion
        #region Методы для подготовки/запуска/завершения игры
        //Метод для инициализации игры
        public void Initialize(decimal savings, DateTime startDate)
        {
            currentSavings = savings;
            ChangeFuelPrice();
            SavingsChanged?.Invoke(this, savings);
            currentGameDate = startDate;
            DateChanged?.Invoke(this, currentGameDate);
        }

        //Метод для старта игры
        public void Start()
        {
            ChangeFuelPrice();
            gameTimer.Start();
        }

        public void Stop()
        {
            gameTimer.Stop();
        }
        #endregion
        #region Методы для получения информации о городах
        //Метод для получения карты расстояний между городами
        public List<Tuple<City, City, double>> GetCitiesDistanceInfo()
        {
            return CitiesInfo.GetCityDistanceGraph();
        }
        //Метод для получения списка городов
        public Dictionary<string, City> GetCitiesInfo()
        {
            return CitiesInfo.cities;
        }
        #endregion
        #region Методы для управления рынком самолетов
        public double GetBuyPrice(Plane.Models model)
        {
            PlaneCharacteristics chars = PlaneCharacteristicsStorage.Characteristics[model];
            int d = GetCurrentDateTime().Day;
            int m = GetCurrentDateTime().Month;
            return 0.1*(chars.Speed * 1000 + chars.Range * 1000 + chars.MaxSeatings * 110) * (Math.Abs(d-m) + 1);
        }

        public void RentPlane(Plane.Models model, double price, int days)
        {
            string planeID = (MaxID + 1).ToString();
            MaxID++;
            Rent rent = new Rent(planeID, days, price);
            Plane plane = new Plane(planeID, model, Plane.Owns.Rented, rent);
            planesAndCities.Add(planeID, CitiesInfo.cities["1"]);
            planes.Add(planeID,plane);
            observablePlanes.Add(plane);
            currentSavings -= (decimal) price * days;
            SavingsChanged?.Invoke(this, currentSavings);
        }

        public void LeasePlane(Plane.Models model, double price, int days)
        {
            string planeID = (MaxID + 1).ToString();
            MaxID++;
            Lease lease = new Lease(planeID, days, price);
            Plane plane = new Plane(planeID, model, Plane.Owns.Leased, lease);
            planesAndCities.Add(planeID, CitiesInfo.cities["1"]);
            planes.Add(planeID, plane);
            observablePlanes.Add(plane);
            currentSavings -= (decimal)price;
            SavingsChanged?.Invoke(this, currentSavings);
        }

        public void BuyPlane(Plane.Models model, double price)
        {
            string planeID = (MaxID + 1).ToString();
            MaxID++;
            Plane plane = new Plane(planeID, model, Plane.Owns.Bought);
            planesAndCities.Add(planeID, CitiesInfo.cities["1"]);
            planes.Add(planeID, plane);
            observablePlanes.Add(plane);
            currentSavings -= (decimal)price;
            SavingsChanged?.Invoke(this, currentSavings);
        }

        public void SellPlane(double Price)
        {
            currentSavings += (decimal) Price;
            SavingsChanged?.Invoke(this, currentSavings);
        }
            
        public void PayFine(double fine)
        {
            currentSavings -= (decimal)fine;
            SavingsChanged?.Invoke(this, currentSavings);
        }

        #endregion
        #region Сохранение/загрузка игры
        public void SaveGame(Stream savedGame)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            IGameLogicInteractable temp = Clone();
            formatter.Serialize(savedGame, temp);
        }

        private IGameLogicInteractable Clone()
        {
            Game clone = new Game();
            clone.currentSavings = currentSavings;

            clone.fuelPrice = fuelPrice;

            clone.planesProgress = new List<PlaneFlight>();
            foreach (PlaneFlight flight in planesProgress)
                clone.planesProgress.Add(flight);

            clone.observablePlanes = new ObservableCollection<Plane>();
            foreach (Plane plane in observablePlanes)
                clone.observablePlanes.Add(plane.Clone());

            clone.planes = new Dictionary<string, Plane>();
            foreach (Plane plane in clone.observablePlanes)
                clone.planes.Add(plane.ID, plane);

            clone.planesAndCities = new Dictionary<string, City>();
            foreach (KeyValuePair<string, City> pair in planesAndCities)
                clone.planesAndCities.Add(pair.Key, pair.Value);

            clone.bulletinBoard = bulletinBoard;

            clone.contracts = new Dictionary<uint, Contract>();
            foreach (KeyValuePair<uint, Contract> pair in contracts)
                clone.contracts.Add(pair.Key, pair.Value);

            clone.observableContracts = new ObservableCollection<Contract>();
            foreach (Contract contract in observableContracts)
                clone.observableContracts.Add(contract);
            return clone;
        }

        //Метод для загрузки игры
        public void LoadGame(Stream savedGame)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            Game loadedGame = (Game)serializer.Deserialize(savedGame);
            Initialize(loadedGame.currentSavings, loadedGame.currentGameDate);

            SavingsChanged?.Invoke(this, currentSavings);

            fuelPrice = loadedGame.fuelPrice;
            FuelPriceChanged?.Invoke(this, fuelPrice);

            planesProgress = loadedGame.planesProgress;
            observablePlanes = loadedGame.observablePlanes;
            planes = loadedGame.planes;

            planesAndCities = loadedGame.planesAndCities;

            bulletinBoard = loadedGame.bulletinBoard;
            contracts = loadedGame.contracts;
            observableContracts = loadedGame.observableContracts;
        }
        #endregion
        #region Игровая логика
        //Основной метод игровой логики
        private void Act(object sender, ElapsedEventArgs e)
        {
            //Имитируем ход игрового времени
            currentGameDate = currentGameDate.AddMinutes(1);
            DateChanged?.Invoke(this, currentGameDate);

            //Каждый час обновляем цену на топливо
            if (currentGameDate.Minute == 0)
                ChangeFuelPrice();

            //Каждые 4 часа обновляем доску с объявлениями
            if (currentGameDate.Hour % 4 == 0 && currentGameDate.Minute == 0)
                UpdateBulletinBoard();

            
            ProcessPlaneFlights();

            InitiateContractsExecution();

            CheckIfGameIsOver();
        }

        //Функция, имитирующая динамическую цену на топливо
        private void ChangeFuelPrice()
        {
            fuelPrice = currentGameDate.Hour * FuelPriceTimeCoeff + BaseFuelPrice;
            FuelPriceChanged?.Invoke(this, fuelPrice);
        }

        private void ProcessPlaneFlights()
        {
            int i = 0;
            while (i < planesProgress.Count)
            {
                PlaneFlight flight = planesProgress[i];
                flight.DistanceLeft -= planes[flight.AssociatedPlaneID].Speed / 60.0;
                planes[flight.AssociatedPlaneID].DeprecationDegree += randomizer.NextDouble() * 0.003;
                planesAndCities[flight.AssociatedPlaneID] = CitiesInfo.cities[flight.DestinationID];
                FlightProgressChanged?.Invoke(this,
                   new FlightProgressEventArgs
                { AssociatedFlight = flight.AssociatedFlightNum, AssociatedPlaneID = flight.AssociatedPlaneID,
                   TimeLeft = TimeSpan.FromHours(flight.DistanceLeft / planes[flight.AssociatedPlaneID].Speed)});
                if (flight.DistanceLeft <= 0)
                {
                    if (flight.AssociatedFlightNum.HasValue)
                        FinishContract(flight.AssociatedFlightNum.Value);
                    if (planes[planesProgress[i].AssociatedPlaneID].Own == Plane.Owns.Rented && planes[planesProgress[i].AssociatedPlaneID].MarketC.Days <= 0)
                    {
                        observablePlanes.Remove(planes[planesProgress[i].AssociatedPlaneID]);
                       // planes.Remove(planesProgress[i].AssociatedPlaneID);

                    }
                    planesProgress.RemoveAt(i);
                    planes[flight.AssociatedPlaneID].status = "";
                }
                else
                    i++;
            }
        }

        //Функция, проводящая случайным образом обновление доски объявлений
        private void UpdateBulletinBoard()
        {
            //Сохраняем ID всех имеющихся городов
            List<string> cityIDs = CitiesInfo.cities.Keys.ToList();
            //Вызываем чистку доски от лишних объявлений
            bulletinBoard.ClearExpiredFlights(currentGameDate);
            //Генерирем число добавляемых объявлений
            int count = randomizer.Next(1, 10);
            //Вызываем генерицию нужного числа объявлений
            for (int i = 1; i <= count; i++)
            {
                Flight newFlight = bulletinBoard.GenerateFlight(currentGameDate, cityIDs);
                newFlight.Profit = newFlight.FlightType == FType.Freight ? randomizer.Next(100, 10000) : newFlight.PasCount * ProfitPerPerson;
            }
        }

        private void FinishContract(uint flightID)
        {
            Contract contract = contracts[flightID];
            if (contract.ConnectedFlights[0].Regularity > 0)
            {
                contract.CountOfPerformedFlights++;
                Flight updFlight = contract.ConnectedFlights.Find(flight => flight.Number == flightID);
                updFlight.DateFrom = updFlight.DateFrom.AddDays(contract.ConnectedFlights[0].Regularity);
                observableContracts[observableContracts.IndexOf(contract)] = contract;
            }
            else contracts.Remove(contract.ConnectedFlights[0].Number);

            Func<decimal> profitFunc = null;
            switch (contract.ConnectedFlights[0].FlightType)
            {
                case FType.Freight:
                    profitFunc = () => contract.ConnectedFlights[0].Profit;
                    break;
                case FType.Passenger:
                    profitFunc = () => randomizer.Next(10, (int)contract.ConnectedFlights[0].PasCount) * ProfitPerPerson;
                    break;
            }

            currentSavings += profitFunc();
        }

        //Проверяем соблюдение контрактов и начинаем выполнение тех, что можем
        private void InitiateContractsExecution()
        {
            foreach (Contract contract in contracts.Values.ToList())
            {
                for (int i = 0; i < contract.ConnectedFlights.Count; i++)
                {
                    if (!ContractIsPrepared(contract, i))
                        continue;
                    SendPlane(contract.AssignedPlane.ID, contract.ConnectedFlights[0].IDTo, contract.ConnectedFlights[0].Number);
                }
            }
        }

        private bool ContractIsPrepared(Contract contract, int flightIdx)
        {
            if (contract.ConnectedFlights[flightIdx].DateFrom.Date != currentGameDate.Date
                || contract.Time != null && 
                    (contract.Time.Hours != currentGameDate.TimeOfDay.Hours 
                    || contract.Time.Minutes != currentGameDate.TimeOfDay.Minutes))
                return false;

            if (contract.AssignedPlane == null || contract.Time == null || planesAndCities[contract.AssignedPlane.ID] == null)
            {
                currentSavings -= contract.Forfeit;
                SavingsChanged?.Invoke(this, currentSavings);
                return false;
            }

            return true;
        }

        //Метод для перегонки самолёта из его текущего положения в другой город
        private decimal SendPlane(string planeID, string destinationID, uint? flightNum)
        {
            double distance = CitiesInfo.GetRoute(planesAndCities[planeID].ID, destinationID).Distance;
            decimal minus = (decimal)distance * fuelPrice;
            currentSavings -= minus;
            SavingsChanged?.Invoke(this, currentSavings);
            planesAndCities[planeID] = null;
            PlaneFlight ongoingFlight = new PlaneFlight
            {
                AssociatedFlightNum = flightNum,
                AssociatedPlaneID = planeID,
                DestinationID = destinationID,
                DistanceLeft = distance
            };
            planesProgress.Add(ongoingFlight);
            return minus;
        }

        //Проверка, не наступил ли Game Over
        private void CheckIfGameIsOver()
        {
            if (currentSavings < 0)
            {
                gameTimer.Stop();
                GameOver?.Invoke(this, new EventArgs());
            }
        }
        #endregion
    }
}
