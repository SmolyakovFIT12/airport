using Airport.GameModel;
using System;
using System.Collections.Generic;

namespace Airport.GameLogic
{
    static class CitiesInfo
    {
        //Словарь названий имеющихся городов, где ключ - ID города, а значение - название города
        public static readonly Dictionary<string, City> cities = new Dictionary<string, City>
        {
            { "1", new City("1", "Пермь") },
            { "2", new City("2", "Москва") },
            { "3", new City("3", "Казань") },
            { "4", new City("4", "Новосибирск") }
        };

        //Список имеющихся путей для перелетов с указанием связанных пунктов и расстояний
        public static readonly List<Route> routes = new List<Route>
        {
            new Route("1", "2", 1158),
            new Route("1", "3", 1858),
            new Route("1", "4", 2176),
            new Route("2", "3", 755),
            new Route("2", "4", 3105),
            new Route("3", "4", 3557)
        };

        public static Route GetRoute(string source, string destination)
        {
            return routes.Find(route =>
                route.SourceCityID.Equals(source) && route.DestinationCityID.Equals(destination) ||
                route.SourceCityID.Equals(destination) && route.DestinationCityID.Equals(source));
        }

        //
        public static List<Tuple<City, City, double>> GetCityDistanceGraph()
        {
            List<Tuple<City, City, double>> result = new List<Tuple<City, City, double>>();
            routes.ForEach(route => result.Add(Tuple.Create(cities[route.SourceCityID], cities[route.DestinationCityID], route.Distance)));
            return result;
        }
    }
}
