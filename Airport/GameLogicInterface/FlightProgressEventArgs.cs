using System;

namespace Airport.GameLogicInterface
{
    public class FlightProgressEventArgs: EventArgs
    {
        public TimeSpan TimeLeft { get; set; }
        public string AssociatedPlaneID { get; set; }
        public uint? AssociatedFlight { get; set; }
    }
}
