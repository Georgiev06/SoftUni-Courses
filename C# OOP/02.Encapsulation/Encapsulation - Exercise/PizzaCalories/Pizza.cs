using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            private set 
            {
                if ((string.IsNullOrEmpty(value)) || (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value; 
            }
        }
        
        public Dough Dough
        {
            get 
            { 
                return this.dough; 
            }
            private set 
            {

                this.dough = value; 
            }
        }
        
        public IReadOnlyCollection<Topping> Toppings
        {
            get 
            { 
                return this.toppings; 
            }
        }

        public void AddToping(Topping toping)
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10]."); 
            }
            else
            {
                this.toppings.Add(toping);
            }
        }

        public double CalculateCalories() => this.Toppings.Sum(x => x.CalculateCalories()) + this.Dough.CalculateCalories();

    }
}
