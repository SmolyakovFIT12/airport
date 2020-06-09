using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.GameModel
{
    [Serializable]
    //класс аренды
    class Rent : MarketContract
    {
        public double Fine { get { return RentPrice * 1.2; } } //штраф
        public double RentPrice { get; } //цена аренды в день
        public Rent(string planeId, int days, double rentPrice) : base(planeId, days)
        {
            this.RentPrice = rentPrice;
        }
    }
}
