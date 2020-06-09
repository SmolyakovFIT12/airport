using System;

namespace Airport.GameModel
{
    [Serializable]
    public class Route
    {
        public string SourceCityID { get; }
        public string DestinationCityID { get; }
        public double Distance { get; }

        public Route(string sourceID, string destinationID, double distance)
        {
            SourceCityID = sourceID;
            DestinationCityID = destinationID;
            Distance = distance;
        }
    }
}
