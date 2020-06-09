using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.GameModel
{
    [Serializable]
    public abstract class MarketContract
    {
        public string PlaneID { get; }
        private int days;
        public int Days { get { return days; } }
        public MarketContract(string planeID, int days)
        {
            this.PlaneID = planeID;
            this.days = days;
        }
        public void NewDay()
        {
            days--;
        }
    }
}
