using System;
using System.Collections.Generic;
using System.Linq;

namespace Objects_and_Classes___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> person = new List<Person>();

            while (command != "End")
            {
                string[] personArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = personArgs[0];
                string id = personArgs[1];
                int age = int.Parse(personArgs[2]);

                int indexToCheck = person.FindIndex(x => x.ID == id);

                if (indexToCheck >= 0)
                {
                    person[indexToCheck].Name = name;
                    person[indexToCheck].Age = age;
                }
                else 
                {
                    Person newPerson = new Person()
                    {
                        Name = name,
                        ID = id,
                        Age = age
                    };

                    person.Add(newPerson);
                }

                command = Console.ReadLine();
            }

            person = person.OrderBy(x => x.Age).ToList();

            foreach (Person people in person)
            {
                Console.WriteLine($"{people.Name} with ID: {people.ID} is {people.Age} years old.");
            }
        }
    }

    class Person
    {     
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

    }
}

