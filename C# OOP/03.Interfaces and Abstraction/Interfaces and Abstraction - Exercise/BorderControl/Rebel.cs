using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        private const int DefaultFoodPortion = 5;
        private int food = 0;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food => food;

        public void BuyFood()
        {
            this.food += DefaultFoodPortion;
        }
    }
}
