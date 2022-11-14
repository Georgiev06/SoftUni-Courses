using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private const int DefaultFoodPortion = 10;
        private int food = 0;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food => food;

        public void BuyFood()
        {
            this.food += DefaultFoodPortion;
        }
    }
}
