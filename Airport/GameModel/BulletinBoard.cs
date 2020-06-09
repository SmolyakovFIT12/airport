using Airport.GameLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Airport.GameModel
{
    [Serializable]
    //Класс доски с объявлениями
    class BulletinBoard
    {
        //Список рейсов на доске
        public ObservableCollection<Flight> Flights { get; }

        //Сроки исчезновения рейсов с доски
        private Dictionary<uint, DateTime> expirationDates;

        //Генератор случайных чисел
        private Random randomizer;

        private uint lastFlightNum;

        public BulletinBoard()
        {
            Flights = new ObservableCollection<Flight>();
            expirationDates = new Dictionary<uint, DateTime>();
            randomizer = new Random();
        }

        public Flight GetFlight(uint flightNum)
        {
            Flight relatedFlight = Flights.First(flight => flight.Number == flightNum);
            Flights.Remove(relatedFlight);
            expirationDates.Remove(flightNum);
            return relatedFlight;
        }

        //Метод для генерации нового рейса
        public Flight GenerateFlight(DateTime currentDate, List<string> cityIDs)
        {
            List<string> unusedCityIDs = new List<string>(cityIDs);
            int idIndex = randomizer.Next(unusedCityIDs.Count);
            string fromID = unusedCityIDs[idIndex];
            unusedCityIDs.RemoveAt(idIndex);

            idIndex = randomizer.Next(unusedCityIDs.Count);
            string toID = unusedCityIDs[idIndex];
            unusedCityIDs.RemoveAt(idIndex);

            lastFlightNum++;
            Flight newFlight = new Flight(lastFlightNum, fromID, toID);
            newFlight.FlightType = (FType)Enum.Parse(typeof(FType), Enum.GetNames(typeof(FType))[randomizer.Next(2)]);
            int lowerBorder = 0;
            int maxBound = 31;
            if (newFlight.FlightType == FType.Passenger)
            {
                lowerBorder = 1;
                newFlight.PasCount = (uint)randomizer.Next(400);
            }
            else
            {
                newFlight.Weight = randomizer.Next(1000, 10000) * 0.01;
                maxBound = (randomizer.Next(0, 2) + 1) * maxBound;
            }

            newFlight.Regularity = (uint)randomizer.Next(lowerBorder, maxBound);
            newFlight.DateFrom = currentDate.AddDays(randomizer.Next(1, 11));
            newFlight.Profit = newFlight.FlightType == FType.Freight ? randomizer.Next(100, 10000) : newFlight.PasCount * GameConstants.ProfitPerPerson;

            expirationDates.Add(newFlight.Number, newFlight.DateFrom);
            Flights.Add(newFlight);
            return newFlight;
        }

        //Очистка истекших рейсов 
        public void ClearExpiredFlights(DateTime currentDate)
        {
            for (int i = 0; i < Flights.Count; i++)
                if (Flights[i].DateFrom.Date == currentDate.Date)
                {
                    uint flightNum = Flights[i].Number;
                    Flights.RemoveAt(i);
                    expirationDates.Remove(flightNum);
                    i--;
                }

            List<uint> keysForRemove = expirationDates
                .Where(pair => pair.Value == currentDate.Date)
                .Select(pair => pair.Key).ToList();
            keysForRemove.ForEach(key =>
            {
                Flights.Remove(Flights.First(flight => flight.Number == key));
                expirationDates.Remove(key);
            });
        }

        public Flight GetRevertedFlight(Flight flight)
        {
            lastFlightNum++;
            Flight revertedFlight = new Flight(lastFlightNum, flight.IDTo, flight.IDFrom);
            revertedFlight.DateFrom = flight.DateFrom.AddDays(1);
            revertedFlight.Regularity = flight.Regularity;
            revertedFlight.FlightType = flight.FlightType;
            revertedFlight.PasCount = flight.PasCount;
            revertedFlight.Weight = flight.Weight;
            return revertedFlight;
        }
    }
}
