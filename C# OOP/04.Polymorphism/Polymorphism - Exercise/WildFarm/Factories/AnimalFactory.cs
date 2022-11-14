using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null)
        {
            Animal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, thirdParam);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, thirdParam);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, thirdParam, fourthParam);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, thirdParam, fourthParam);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return animal;
        }
    }
}
