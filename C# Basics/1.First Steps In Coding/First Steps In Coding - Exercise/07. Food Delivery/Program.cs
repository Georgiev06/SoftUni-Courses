using System;

namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegiterianMenu = int.Parse(Console.ReadLine());

            double priceOfChickenMenu = chickenMenu * 10.35;
            double priceOfFishMenu = fishMenu * 12.40;
            double priceOfVegiterianMenu = vegiterianMenu * 8.15;
            double desertPrice = 18.95;
            double deliveryPrice = 2.50;

            double totalprice = priceOfChickenMenu + priceOfFishMenu + priceOfVegiterianMenu;
            double orderPrice = totalprice + desertPrice + deliveryPrice;

            Console.WriteLine(orderPrice);
        }
    }
}
