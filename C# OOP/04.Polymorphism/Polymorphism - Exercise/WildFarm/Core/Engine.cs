using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory, IReader reader, IWriter writer)
            : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = command
                        .Split();
                    string[] foodArgs = this.reader.ReadLine()
                        .Split();

                    Animal animal = BuildAnimalUsingFactory(animalArgs);
                    Food food = this.foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));

                   this.writer.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeException ifte)
                {
                    this.writer.WriteLine(ifte.Message);
                }
                catch (FoodNotPreferredException fnpe)
                {
                    this.writer.WriteLine(fnpe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }

        private Animal BuildAnimalUsingFactory(string[] animalArgs)
        {
            Animal animal;
            if (animalArgs.Length == 4)
            {
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, thirdParam);
            }
            else if (animalArgs.Length == 5)
            {
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];
                string fourthParam = animalArgs[4];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, thirdParam, fourthParam);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
