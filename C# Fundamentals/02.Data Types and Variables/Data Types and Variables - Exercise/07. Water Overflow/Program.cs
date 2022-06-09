using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int n = int.Parse(Console.ReadLine());
			var capacity = 255;
			for (int i = 0; i < n; i++)
			{
				int quantityWater = int.Parse(Console.ReadLine());

				if (quantityWater <= capacity)
				{
					capacity -= quantityWater;
				}
				else
					Console.WriteLine("Insufficient capacity!");
			}
			var left = 255 - capacity;
			Console.WriteLine(left);
		}
    }
}
