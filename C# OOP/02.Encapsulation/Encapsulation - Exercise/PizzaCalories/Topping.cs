using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;
        private double toppingModifier;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
            this.ToppingModifier = toppingModifier;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if ((string.IsNullOrEmpty(value)) || (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce"))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.grams = value;
            }
        }

        public double ToppingModifier
        {
            get
            {
                return this.toppingModifier;
            }
            private set
            {
                if (this.Type.ToLower() == "meat")
                {
                    this.toppingModifier = 1.2;
                }
                else if (this.Type.ToLower() == "veggies")
                {
                    this.toppingModifier = 0.8;
                }
                else if (this.Type.ToLower() == "cheese")
                {
                    this.toppingModifier = 1.1;
                }
                else if (this.Type.ToLower() == "sauce")
                {
                    this.toppingModifier = 0.9;
                }
            }
        }

        public double CalculateCalories()  => (this.Grams * this.ToppingModifier) * 2;
    }
}
