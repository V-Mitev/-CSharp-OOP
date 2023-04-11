﻿using System;

namespace P03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public string Add(Product product)
        {
            if (product.Cost > Money)
            {
                return $"{Name} can't afford {product.Name}";
            }

            products.Add(product);
            Money -= product.Cost;

            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            string productString = products.Any() ? string.Join(", ", products.Select(x=> x.Name)) : "Nothing bought";

            return $"{Name} - {productString}";
        }
    }
}