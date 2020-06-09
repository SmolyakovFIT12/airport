using System;
using System.Collections.Generic;

namespace Airport.GameModel
{
    [Serializable]
    //Класс контракта
    public class Contract
    {
        //Связанные с контрактом рейс
        public List<Flight> ConnectedFlights { get; }

        //Самолёт, назначенный на контракт
        public Plane AssignedPlane { get; set; }

        //Время вылета
        public TimeSpan Time { get; set; }

        //Число произведенных вылетов
        public int CountOfPerformedFlights { get; set; }

        //Неустойка
        public decimal Forfeit { get; set; }

        public Contract(params Flight[] flights)
        {
            ConnectedFlights = new List<Flight>();
            foreach (Flight flight in flights)
                ConnectedFlights.Add(flight);
        }
    }
}
