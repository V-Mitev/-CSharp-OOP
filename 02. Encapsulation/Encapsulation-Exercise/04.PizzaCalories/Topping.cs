using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
        Dictionary<string, double> modifires = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9}
        };

        private string toppingType;
        private int grams;

        public Topping(int grams, string toppingType)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        private const int DefaultToppingCalories = 2;

        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                if (!modifires.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public int Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double Calories
            => DefaultToppingCalories * Grams * modifires[toppingType.ToLower()];
    }
}