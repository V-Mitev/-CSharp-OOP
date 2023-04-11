using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) 
                        : base(name, 3.50m, 50)
        {
            Caffeine = caffeine;
        }

        public override double Milliliters => 50;

        public override decimal Price => 3.50M;

        public double Caffeine { get; set; }
    }
}
