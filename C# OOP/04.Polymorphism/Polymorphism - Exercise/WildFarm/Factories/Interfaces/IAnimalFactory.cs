using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
