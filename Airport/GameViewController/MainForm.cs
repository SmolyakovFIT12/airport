using Airport.GameLogicInterface;
using System;
using System.Drawing;
using System.Windows.Forms;
using Airport.AirportUserControls;
using Airport.GameModel;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;

namespace Airport.GameViewController
{
    [Serializable]
    public partial class MainForm : Form
    {
        // для кнопки доски объявлений
        UserBoard userBoard = new UserBoard();
        // для кнопки авиакомпаний
        UserScroll userAiroportPlanes = new UserScroll();
        UserScroll userAiroportContracts = new UserScroll();
        // для кнопки покупки/продажи самолетов
        UserScroll userMarketPlanesSell = new UserScroll();
        UserScroll userMarketPlanesBuy = new UserScroll();

        private IGameLogicInteractable game;
        //List<City> cities;

        Dictionary<string, City> cities;
        ObservableCollection<Contract> contracts;
        ObservableCollection<Flight> flights;
        ObservableCollection<Plane> planes;
     
        public static Color MostlyBackColor { get { return Color.FromArgb(255,255,255); } }

        int contractsStartX = 10;
        int contractsStartY = 5;

        int startBoardX = 20;
        int startBoardY = 0;
        int newBoardX = 0;
        bool isFirstX = true;

        public MainForm(IGameLogicInteractable game)
        {
            InitializeComponent();
            this.game = game;
            game.FlightProgressChanged += Game_FlightProgressChanged;
            game.GameOver += Game_GameOver;
            contracts = game.GetContracts();
            contracts.CollectionChanged += Contracts_CollectionChanged;
            flights = game.GetFlightsInfo();
            flights.CollectionChanged += Flights_CollectionChanged;
            cities = game.GetCitiesInfo();
            planes = game.GetPlanes();
            planes.CollectionChanged += Planes_CollectionChanged;

            lblDateValue.Text = game.GetCurrentDateTime().ToLongDateString();
            lblBalanceValue.Text = "$ " + game.GetSavings().ToString();
            lblTimeValue.Text = game.GetCurrentDateTime().TimeOfDay.ToString("hh\\:mm");
            lblFuelValue.Text = "$ " + game.GetFuelPrice().ToString();

            game.SavingsChanged += Game_SavingsChanged;
            game.DateChanged += Game_DateChanged;
            game.FuelPriceChanged += Game_FuelPriceChanged;
            
            btnUpOne.FlatAppearance.BorderSize = 0;
            btnUpTwo.FlatAppearance.BorderSize = 0;
            btnUpThree.FlatAppearance.BorderSize = 0;

            InitLayoutControls();
            StartupLayoutInit();
            FillPlanes(PlaneDataType.TransferPlane, userAiroportPlanes);
            FillContracts();
            FillBoard();
            FillPlanes(PlaneDataType.SellPlane, userMarketPlanesSell);
            FillPlanesMarket(userMarketPlanesBuy);
       }

        private void Game_ContractUpdated(object sender, uint e)
        {
            throw new NotImplementedException();
        }

        private void Game_FlightProgressChanged(object sender, FlightProgressEventArgs e)
        {
            if (!planesUI.ContainsKey(e.AssociatedPlaneID))
                return;
            if (planesUI[e.AssociatedPlaneID].IsHandleCreated)
            {
                planesUI[e.AssociatedPlaneID].Invoke(new Action(() => planesUI[e.AssociatedPlaneID].CityName = e.TimeLeft.TotalMinutes > 0 ?
                  "В полёте" : game.GetPlaneLocation(e.AssociatedPlaneID).Name));
                planesUI[e.AssociatedPlaneID].Invoke(new Action(() => planesUI[e.AssociatedPlaneID].Plane.status = e.TimeLeft.TotalMinutes > 0 ? "В полёте" :
                    ""));
            }
            else
            {
                planesUI[e.AssociatedPlaneID].CityName = e.TimeLeft.TotalMinutes > 0 ?
                "В полёте" : game.GetPlaneLocation(e.AssociatedPlaneID).Name;
                planesUI[e.AssociatedPlaneID].Plane.status = e.TimeLeft.TotalMinutes > 0 ?
                    "В полёте" : "";
            }
            if (e.AssociatedFlight.HasValue && contractsUI.ContainsKey(e.AssociatedFlight.Value))
            {
                if (contractsUI[e.AssociatedFlight.Value].IsHandleCreated)
                    contractsUI[e.AssociatedFlight.Value].Invoke(new Action(() => 
                        contractsUI[e.AssociatedFlight.Value].TimeValue = e.TimeLeft));
                else contractsUI[e.AssociatedFlight.Value].TimeValue = e.TimeLeft;
            }
        }

        private Dictionary<string, PlaneData> planesUI = new Dictionary<string, PlaneData>();
        private Dictionary<string, PlaneData> planesToSellUI = new Dictionary<string, PlaneData>();

        private void FillPlanes(PlaneDataType type, UserScroll userScroll)
        {
            // основные характеристики
            int planesStartX = 10;
            int planesStartY = 5;
            foreach (var plane in game.GetPlanes())
            {
                PlaneData planeData = new PlaneData(type, game, cities.Values.ToList(), plane)
                {
                    PlaneName = plane.Model.ToString(),
                    CityName = game.GetPlaneLocation(plane.ID) == null ? "-"
                    : game.GetPlaneLocation(plane.ID).Name,
                    SpeedValue = plane.Speed,
                    DeprecationValue = plane.DeprecationDegree,
                    Location = new Point(planesStartX, planesStartY),
                    PriceValue = Math.Round(game.GetBuyPrice(plane.Model) * 0.7, 1),
                    DefaultPrice = Math.Round(game.GetBuyPrice(plane.Model) * 0.7, 1)
                };
                planesStartY += planeData.Height + 10;
                if (userScroll.GetPanel.IsHandleCreated)
                    userScroll.GetPanel.Invoke(new Action(() => userScroll.GetPanel.Controls.Add(planeData)));
                else userScroll.GetPanel.Controls.Add(planeData);
                switch (type)
                {
                    case PlaneDataType.SellPlane:
                        planesToSellUI.Add(plane.ID, planeData);
                        break;
                    case PlaneDataType.TransferPlane:
                        planesUI.Add(plane.ID, planeData);
                        break;
                }
            }
        }


        private void FillPlanesMarket(UserScroll userScroll)
        {
            // основные характеристики
            int planesStartX = 10;
            int planesStartY = 5;
            List<Plane.Models> models = new List<Plane.Models>();
            models.Add(Plane.Models.TY_134);
            models.Add(Plane.Models.SuperJet123);
            models.Add(Plane.Models.KukuruznikMX150);

            foreach (var model in models)
            {
                PlaneMarket planeMarket = new PlaneMarket(game, model, 5)
                {
                   Location = new Point(planesStartX, planesStartY)
                };
                planesStartY += planeMarket.Height + 10;
                if (userScroll.GetPanel.IsHandleCreated)
                    userScroll.GetPanel.Invoke(new Action(() => userScroll.GetPanel.Controls.Add(planeMarket)));
                else userScroll.GetPanel.Controls.Add(planeMarket);
                //  planesUI.Add(plane.ID, planeData);
              
             }
            
        }

        private void UpdatePlanesMarket()
        {
            userMarketPlanesBuy.Invoke(new Action(() => userMarketPlanesBuy.GetPanel.Controls.Clear()));
             FillPlanesMarket(userMarketPlanesBuy);
        }
        public void UpdatePlanes()
        {
            planesUI.Clear();
            planesToSellUI.Clear();
            userMarketPlanesSell.Invoke(new Action(() => userMarketPlanesSell.GetPanel.Controls.Clear()));
            FillPlanes( PlaneDataType.SellPlane, userMarketPlanesSell);
            userAiroportPlanes.Invoke(new Action(() => userAiroportPlanes.GetPanel.Controls.Clear()));
            FillPlanes(PlaneDataType.TransferPlane, userAiroportPlanes);
           
        }

        private void Flights_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var obj in e.NewItems)
                            if (e.OldItems == null || !e.OldItems.Contains(obj))
                                AddFlight((Flight)obj);
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (var obj in e.OldItems)
                            if (e.NewItems == null || !e.NewItems.Contains(obj))
                            {
                                Flight removedFlight = (Flight)obj;
                                if (userBoard.GetPanel.IsHandleCreated)
                                    userBoard.GetPanel.Invoke(new Action(() => 
                                        userBoard.GetPanel.Controls.Remove(flightsUI[removedFlight.Number])));
                                else userBoard.GetPanel.Controls.Remove(flightsUI[removedFlight.Number]);
                                flightsUI.Remove(removedFlight.Number);
                            }
                        startBoardX = 20;
                        startBoardY = 0;
                        newBoardX = 0;
                        isFirstX = true; List<Control> controls = new List<Control>();
                        foreach (Control control in userBoard.GetPanel.Controls)
                            controls.Add(control);
                        if (userBoard.GetPanel.IsHandleCreated)
                            userBoard.GetPanel.Invoke(new Action(() => userBoard.GetPanel.Controls.Clear()));
                        else userBoard.GetPanel.Controls.Clear();
                        foreach (Control control in controls)
                            if (control is FlightData)
                                AddFlightData((FlightData)control);
                        break;
                    }
            }
        }

        private void Contracts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var obj in e.NewItems)
                            if (e.OldItems == null || !e.OldItems.Contains(obj))
                                AddContract((Contract)obj);
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {
                        foreach (var obj in e.NewItems)
                            foreach (Flight f in ((Contract)obj).ConnectedFlights)
                                if (contractsUI[f.Number].IsHandleCreated)
                                    contractsUI[f.Number].Invoke(new Action(() => contractsUI[f.Number].DateValue = f.DateFrom));
                                else contractsUI[f.Number].DateValue = f.DateFrom;
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (var obj in e.OldItems)
                            if (e.NewItems == null || !e.NewItems.Contains(obj))
                            {
                                Contract contract = (Contract)obj;
                                foreach (Flight flight in contract.ConnectedFlights)
                                {
                                    if (userAiroportContracts.GetPanel.IsHandleCreated)
                                        userAiroportContracts.GetPanel.Invoke(new Action(() => 
                                         userAiroportContracts.GetPanel.Controls.Remove(contractsUI[flight.Number])));
                                    else userAiroportContracts.GetPanel.Controls.Remove(contractsUI[flight.Number]);
                                    contractsUI.Remove(flight.Number);
                                }
                            }
                        List<Control> controls = new List<Control>();
                        foreach (Control control in userAiroportContracts.GetPanel.Controls)
                            controls.Add(control);
                        if (userAiroportContracts.GetPanel.IsHandleCreated)
                            userAiroportContracts.GetPanel.Invoke(new Action(() => userAiroportContracts.GetPanel.Controls.Clear()));
                        else userAiroportContracts.GetPanel.Controls.Clear();
                        contractsStartX = 10;
                        contractsStartY = 5;
                        foreach (Control control in controls)
                            if (control is ContractData)
                                AddContractData((ContractData)control);
                        break;
                    }
            }
        }

        private void Planes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdatePlanes();
        }

        private void Game_GameOver(object sender, EventArgs e)
        {
            game.Stop();
            MessageBox.Show("А у вас деньги закончились, и вы теперь не директор авиакомпании, а обычный безработный", "Game Over",
                MessageBoxButtons.OK);
        }

        private void Game_FuelPriceChanged(object sender, decimal newFuelPrice)
        {
            FuelValue = newFuelPrice;
        }

        private void Game_DateChanged(object sender, DateTime gameDate)
        {
            DateTime oldDate = DateValue;
            DateValue = gameDate;
            TimeValue = gameDate.TimeOfDay;
            //новый день
            if (! (oldDate.Day == gameDate.Day && oldDate.Month == gameDate.Month))
            {
                 UpdatePlanesMarket();
                List<Plane> planesToRemove = new List<Plane>();
                 foreach (Plane plane in planes)
                {
                   
                    if (plane.Own == Plane.Owns.Rented)
                    {
                        plane.MarketC.NewDay();
                        if (plane.MarketC.Days <= 0)
                        {
                            if (planesUI[plane.ID].CityName == "В полёте")
                            {
                                game.PayFine(((Rent)plane.MarketC).Fine);
                            }
                            else
                            {
                                planesToRemove.Add(plane);
                            }
                        }
                    }
                    if (plane.Own == Plane.Owns.Leased && plane.MarketC.Days > 0)
                    {
                        plane.MarketC.NewDay();
                        if (plane.MarketC.Days > 0)
                        {
                            game.PayFine(((Lease)plane.MarketC).LeasePrice);
                        }
                    }
                }
                 foreach (Plane plane  in planesToRemove)
                {
                    planes.Remove(plane);
                }
                 UpdatePlanes();
            }
        }

        private void Game_SavingsChanged(object sender, decimal newSavings)
        {
            BalanceValue = newSavings;
        }

        private void InitLayoutControls()
        {
            // начало расположения вышеперечисленных элементов на главной форме
            int mainX = 14, mainY = 110, mainNewX = mainX + userAiroportPlanes.Width + 20;

            userAiroportPlanes.SetLocation(mainX, mainY);
            userAiroportPlanes.Text = "Ваши самолеты";
            this.Controls.Add(userAiroportPlanes);

            userAiroportContracts.SetLocation(mainNewX, mainY);
            userAiroportContracts.Text = "Ваши контракты";
            this.Controls.Add(userAiroportContracts);

            userBoard.SetLocation(mainX, mainY);
            this.Controls.Add(userBoard);

            userMarketPlanesSell.SetLocation(mainX, mainY);
            userMarketPlanesSell.Text = "Ваши самолеты";
            this.Controls.Add(userMarketPlanesSell);

            userMarketPlanesBuy.SetLocation(mainNewX, mainY);
            userMarketPlanesBuy.Text = "Покупка самолетов";
            this.Controls.Add(userMarketPlanesBuy);
        }

        private void FillContracts()
        {
            // основные характеристики
            contractsStartX = 10;
            contractsStartY = 5;
            foreach (var contract in game.GetContracts())
                AddContract(contract);
            Controls.Add(userAiroportContracts);
        }

        private Dictionary<uint, ContractData> contractsUI = new Dictionary<uint, ContractData>();

        private void AddContract(Contract contract)
        {
            foreach (var flight in contract.ConnectedFlights)
            {
                bool isPassenger = flight.FlightType == FType.Passenger;
                ContractData contractData = new ContractData(isPassenger, game, contract, flight)
                {
                    FlightName = cities[flight.IDFrom] + " - " + cities[flight.IDTo],
                    TypeValue = isPassenger ? flight.PasCount.ToString() : string.Format("{0:0.00}",flight.Weight),
                    StatusValue = "не готов",
                    DateValue = flight.DateFrom
                };
                AddContractData(contractData);
                contractsUI.Add(flight.Number, contractData);
            }
        }

        private void AddPlane(Plane plane, PlaneDataType type)
        {
            PlaneData planeData = new PlaneData(type, game, cities.Values.ToList(), plane)
            {
                PlaneName = plane.Model.ToString(),
                CityName = game.GetPlaneLocation(plane.ID) == null ? "-"
                     : game.GetPlaneLocation(plane.ID).Name,
                SpeedValue = plane.Speed,
                DeprecationValue = plane.DeprecationDegree,
                PriceValue = Math.Round(game.GetBuyPrice(plane.Model) * 0.7, 1),
                DefaultPrice = Math.Round(game.GetBuyPrice(plane.Model) * 0.7, 1)
            };
            switch (type)
            {
                case PlaneDataType.TransferPlane:
                    AddPlaneData(planeData);
                    break;
                case PlaneDataType.SellPlane:
                    AddPlaneDataSell(planeData);
                    break;
            }
            planesUI.Add(plane.ID, planeData);
        }

        private void AddPlaneData(PlaneData planeData)
        {
            int planesStartX = 10;
            int planesStartY = 5;
            planeData.Location = new Point(planesStartX, planesStartY);
            planesStartY += planeData.Height + 10;
            if (userAiroportPlanes.IsHandleCreated)
                userAiroportPlanes.Invoke(new Action(() => userAiroportPlanes.GetPanel.Controls.Add(planeData)));
            else userAiroportPlanes.GetPanel.Controls.Add(planeData);
        }

        private void AddPlaneDataSell (PlaneData planeData)
        {
            int planesStartX = 10;
            int planesStartY = 5;
            planeData.Location = new Point(planesStartX, planesStartY);
            planesStartY += planeData.Height + 10;
            if (userMarketPlanesSell.IsHandleCreated)
                userMarketPlanesSell.Invoke(new Action(() => userMarketPlanesSell.GetPanel.Controls.Add(planeData)));
            else userMarketPlanesSell.GetPanel.Controls.Add(planeData);
        }

        private void AddContractData(ContractData contractData)
        {
            contractData.Location = new Point(contractsStartX, contractsStartY);
            contractsStartY += contractData.Height + 10;
            if (userAiroportContracts.IsHandleCreated)
                userAiroportContracts.Invoke(new Action(() => userAiroportContracts.GetPanel.Controls.Add(contractData)));
            else userAiroportContracts.GetPanel.Controls.Add(contractData);
        }

        private string GetType(bool IsPassenger)
        {
            return (IsPassenger ? "Регулярный" : "Разовый");
        }

        private void FillBoard()
        {
            // основные характеристики
            startBoardX = 20;
            startBoardY = 0;
            newBoardX = 0;
            isFirstX = true;
            foreach (var flight in game.GetFlightsInfo())
                AddFlight(flight);
        }

        private Dictionary<uint, FlightData> flightsUI = new Dictionary<uint, FlightData>();

        private void AddFlight(Flight flight)
        {
            bool isPassenger = flight.FlightType == FType.Passenger;
            FlightData flightData = new FlightData(isPassenger, flight, game)
            {
                FlightName = cities[flight.IDFrom] + " - " + cities[flight.IDTo],
                FlightTypeValue = isPassenger ? flight.PasCount.ToString() : string.Format("{0:0.00}", flight.Weight),
                DateValue = flight.DateFrom,
                TypeValue = GetType(flight.Regularity > 0),
                PriceValue = flight.Profit
            };
            AddFlightData(flightData);
            flightsUI.Add(flight.Number, flightData);
        }

        private void AddFlightData(FlightData flightData)
        {
            if (flightData.IsHandleCreated)
                flightData.Invoke(new Action(() => flightData.Location = new Point(isFirstX ? startBoardX : newBoardX, startBoardY)));
            else flightData.Location = new Point(isFirstX ? startBoardX : newBoardX, startBoardY);
            startBoardY = isFirstX ? startBoardY : startBoardY + flightData.Height + 10;
            newBoardX = startBoardX + flightData.Width + 30;
            isFirstX = !isFirstX;
            if (userBoard.IsHandleCreated)
                userBoard.Invoke(new Action(() => userBoard.GetPanel.Controls.Add(flightData)));
            else userBoard.GetPanel.Controls.Add(flightData);
        }

        private DateTime DateValue
        {
            get { return DateTime.Parse(lblDateValue.Text); }
            set { if (lblDateValue.IsHandleCreated) lblDateValue.Invoke(new Action(() => lblDateValue.Text = value.ToLongDateString())); }
        }

        public decimal BalanceValue
        {
            get { return uint.Parse(lblBalanceValue.Text.Replace("$ ", "")); }
            set { if (lblBalanceValue.IsHandleCreated) lblBalanceValue.Invoke(new Action(() => lblBalanceValue.Text = "$ " + value.ToString())); }
        }

        private TimeSpan TimeValue
        {
            get { return TimeSpan.Parse(lblTimeValue.Text); }
            set { if (lblTimeValue.IsHandleCreated) lblTimeValue.Invoke(new Action(() => lblTimeValue.Text = value.ToString("hh\\:mm"))); }
        }

        private decimal FuelValue
        {
            get { return decimal.Parse(lblFuelValue.Text.Replace("$ ", "")); }
            set { if (lblFuelValue.IsHandleCreated) lblFuelValue.Invoke(new Action(() => lblFuelValue.Text = "$ " + value.ToString())); }
        }

        private void StartupLayoutInit()
        {
            userAiroportPlanes.Visible = true;
            userAiroportContracts.Visible = true;
            userBoard.Visible = false;
            userMarketPlanesSell.Visible = false;
            userMarketPlanesBuy.Visible = false;
        }

        private void BtnAirline_Click(object sender, EventArgs e)
        {
            StartupLayoutInit();
            lblTime.Visible = true;
            lblTimeValue.Visible = true;
            lblFuel.Visible = true;
            lblFuelValue.Visible = true;
        }

        private void BtnBoard_Click(object sender, EventArgs e)
        {
            userBoard.Visible = true;
            userAiroportPlanes.Visible = false;
            userAiroportContracts.Visible = false;
            userMarketPlanesSell.Visible = false;
            userMarketPlanesBuy.Visible = false;
            lblTime.Visible = true;
            lblTimeValue.Visible = true;
            lblFuel.Visible = true;
            lblFuelValue.Visible = true;
        }

        private void BtnPlanesMarket_Click(object sender, EventArgs e)
        {
            userMarketPlanesSell.Visible = true;
            userMarketPlanesBuy.Visible = true;
            userBoard.Visible = false;
            userAiroportPlanes.Visible = false;
            userAiroportContracts.Visible = false;
            lblTime.Visible = true;
            lblTimeValue.Visible = true;
            lblFuel.Visible = true;
            lblFuelValue.Visible = true;
        }


        private void СохранитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Stop();
            try
            {
                using (FileStream stream = File.Open("LastGame.game", FileMode.OpenOrCreate))
                    game.SaveGame(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            game.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.Stop();
            Application.Exit();
        }
        private void btnsinvert(object sender)
        {
            btnUpThree.Enabled = btnUpTwo.Enabled = btnUpOne.Enabled = true;
            ((Button)sender).Enabled = false;
        }

        private void BtnUpOne_Click(object sender, EventArgs e)
        {
            game.CurrentGameSpeed = GameSpeeds.x1;
            btnsinvert(sender);
        }

        private void BtnUpTwo_Click(object sender, EventArgs e)
        {
            game.CurrentGameSpeed = GameSpeeds.x50;
            btnsinvert(sender);
        }

        private void BtnUpThree_Click(object sender, EventArgs e)
        {
            game.CurrentGameSpeed = GameSpeeds.x100;
            btnsinvert(sender);
        }

        private void ЗагрузитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Stop();
            try
            {
                if (File.Exists("LastGame.game"))
                {
                    using (FileStream stream = File.Open("LastGame.game", FileMode.Open))
                        game.LoadGame(stream);
                }
                else MessageBox.Show("К сожалению, предыдущие сохранения не найдены");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            game.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
