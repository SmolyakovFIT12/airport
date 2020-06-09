using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.GameModel
{
    [Serializable]
    //класс аренды
    class Lease : MarketContract
    {
        public double LeasePrice { get; } //цена лизинга в день
        public Lease(string planeId, int days, double leasePrice) : base(planeId, days)
        {
            this.LeasePrice = leasePrice;
        }
    }
}
