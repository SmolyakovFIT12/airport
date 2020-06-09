using Airport.GameModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Airport.GameLogicInterface
{
    public interface IGameLogicInteractable
    {
        #region Игровые параметры
        //Свойство скорости игры
        GameSpeeds CurrentGameSpeed { get; set; }

        //Метод для получения игрового времени
        DateTime GetCurrentDateTime();

        //Метод для получения цены на топливо
        decimal GetFuelPrice();
        #endregion
        #region Информация об игроке
        //Метод для получения финансовой информации игрока
        decimal GetSavings();

        //метод получения цены покупки для данной модели
        double GetBuyPrice(Plane.Models model);

        //метод аренды самолета
        void RentPlane(Plane.Models model, double price, int days);
        //метод лизинга самолета
        void LeasePlane(Plane.Models model, double price, int days);

        //Метод покупки самолета.
        void BuyPlane(Plane.Models model, double price);

        //Метод продажи самолета.
        void SellPlane(double price);
        //выплата штрафа
        void PayFine(double fine);
        //Метод для получения списка имеющихся
        //у игрока самолётов
        ObservableCollection<Plane> GetPlanes();
        #endregion
        #region Методы для получения информации о самолетах (местоположение, назначение и т.п.) 
        //Метод для получения информации о местоположении всех самолётов
        List<Tuple<string, City>> GetLocationsOfAllPlanes();

        //Метод для получения информации о местоположении самолёта по его ID
        City GetPlaneLocation(string ID);
        #endregion
        #region Методы для работы с рейсами и контрактами
        //Метод для получения списка имеющихся
        //на доске объявлений рейсов
        ObservableCollection<Flight> GetFlightsInfo();

        ObservableCollection<Contract> GetContracts();

        //Метод для подписания контракта на заданный рейс
        void SignContract(uint flightNum);

        //Метод для отмены подписанного контракта
        void CancelContract(uint flightNum);

        //Метод для назначения самолёта на контракт
        bool AssignPlaneToContract(string planeID, uint flightNum);

        //Метод для отмены назначения самолёта на контракт
        void ResetPlaneForContract(uint flightNum);

        //Метод для назначения времени вылета в контракт
        void SetTimeForContract(uint flightNum, TimeSpan time);

        //Метод для перебазирования самолёта (пустой перелёт в другой город)
        decimal RebasePlane(string planeID, string destinationID);
        #endregion
        #region Методы для подготовки/запуска/завершения игры
        //Метод инициализации игры
        void Initialize(decimal savings, DateTime startDate);

        //Метод для запуска игры
        void Start();

        //Метод для завершения игры
        void Stop();
        #endregion
        #region Методы для получения информации о городами
        //Метод для получения карты расстояний между городами
        List<Tuple<City, City, double>> GetCitiesDistanceInfo();
        Dictionary<string, City> GetCitiesInfo();
        #endregion
        #region Сохранение/загрузка игры
        void SaveGame(Stream savedGame);

        //Метод для загрузки игры из переданного потока
        void LoadGame(Stream savedGame);
        #endregion
        #region Игровые события
        //Событие, происходящее при изменении финансов игрока 
        event EventHandler<decimal> SavingsChanged;

        //Событие, происходящее при изменении игровой даты/времени
        event EventHandler<DateTime> DateChanged;

        event EventHandler<FlightProgressEventArgs> FlightProgressChanged; 

        //Событие, происходящее при изменении цены на топливо
        event EventHandler<decimal> FuelPriceChanged;

        //Событие, происходящее при проигрыше
        event EventHandler GameOver;
        #endregion
    }
}
