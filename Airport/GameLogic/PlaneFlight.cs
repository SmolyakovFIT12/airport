using System;

namespace Airport.GameLogic
{
    [Serializable]
    class PlaneFlight
    {
        public double DistanceLeft { get; set; }
        public uint? AssociatedFlightNum { get; set; }
        public string DestinationID { get; set; }
        public string AssociatedPlaneID { get; set; }
    }
}
