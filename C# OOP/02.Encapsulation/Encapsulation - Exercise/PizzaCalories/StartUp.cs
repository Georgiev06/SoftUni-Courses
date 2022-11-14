using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaData = Console.ReadLine().Split(" ");
                string[] doughData = Console.ReadLine().Split(" ");

                Dough dough = new Dough(doughData[1], doughData[2], double.Parse(doughData[3]));
                Pizza pizza = new Pizza(pizzaData[1], dough);
                try
                {
                    string command;
                    while ((command = Console.ReadLine()) != "END")
                    {
                        string[] dataTopping = command.Split(" ");
                        Topping topping = new Topping(dataTopping[1], double.Parse(dataTopping[2]));
                        pizza.AddToping(topping);
                    }

                    Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():f2} Calories.");
                    return;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
