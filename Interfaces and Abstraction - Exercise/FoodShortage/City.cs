using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class City
    {
        public City()
        {
            this.Citizens = new List<Citizen>();
            this.Rebels = new List<Rebel>();
        }

        public List<Citizen> Citizens { get; private set; }

        public List<Rebel> Rebels { get; private set; }
    }
}
