using System;

namespace Airport.GameModel
{
    // Перечисление для указания типа рейса
    public enum FType { Passenger, Freight }

    [Serializable]
    // класс рейса
    public class Flight
    {
        // Номер рейса
        public uint Number { get; }
        // Регулярность рейса - число дней между выполнениями рейса, 0 – для разовых рейсов
        public uint Regularity { get; set; }
        // Тип рейса (пассажирский/грузовой)
        public FType FlightType { get; set; }
        // ID пункта отправления
        public string IDFrom { get; set; }
        // ID пункта назначения
        public string IDTo { get; set; }
        // Число пассажиров на рейсе
        public uint PasCount { get; set; }
        // Вес груза, который берется в рейс, в тоннах
        public double Weight { get; set; }
        // Дата вылета
        public DateTime DateFrom { get; set; }
        //Прибыль с грузового рейса
        public decimal Profit { get; set; }

        public Flight(uint number, string iDFrom, string iDTo)
        {
            Number = number;
            IDFrom = iDFrom;
            IDTo = iDTo;
        }
    }
}
