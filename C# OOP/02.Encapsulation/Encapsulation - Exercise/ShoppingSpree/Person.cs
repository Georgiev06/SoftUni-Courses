using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bag;
        private Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag;
            }
        }
        public void AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.bag.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - {string.Join(", ", this.bag)}";
            }
        }
    }
}
