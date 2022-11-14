using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> peopleInfo = new Queue<string>(Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList());

            List<Person> people = new List<Person>();
            var productsInfo = new Queue<string>(Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList());

            List<Product> products = new List<Product>();

            while (peopleInfo.Any())
            {
                var currentPerson = peopleInfo.Dequeue().Split("=", StringSplitOptions.RemoveEmptyEntries);

                Person person;
                try
                {
                    person = new Person(currentPerson[0], decimal.Parse(currentPerson[1]));
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }

            }
            while (productsInfo.Any())
            {

                var currentProduct = productsInfo.Dequeue().Split("=", StringSplitOptions.RemoveEmptyEntries);
                Product product;
                try
                {
                    product = new Product(currentProduct[0], decimal.Parse(currentProduct[1]));
                    products.Add(product);

                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var person = people.Find(x => x.Name.Equals(commandArgs[0]));

                var product = products.Find(x => x.Name.Equals(commandArgs[1]));

                if (person != null && product != null)
                {
                    try
                    {
                        person.AddProduct(product);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        continue;
                    }
                }
            }

            people.ForEach(person => Console.WriteLine(person));
        }
    }
}
