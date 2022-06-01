using System;

namespace _04._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int goalSteps = 10000;

            int stepsOver = 0;

            while (stepsOver < goalSteps)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    int stepsLeft = int.Parse(Console.ReadLine());
                    stepsOver += stepsLeft;
                    break;
                }
                int currentSteps = int.Parse(input);
                stepsOver += currentSteps;
            }

            if (stepsOver >= goalSteps)
            {
                Console.WriteLine($"Goal reached! Good job!");
                int stepsOverTheGoal = stepsOver - goalSteps;
                Console.WriteLine($"{stepsOverTheGoal} steps over the goal!");
            }
            else
            {
                int different = goalSteps - stepsOver;
                Console.WriteLine($"{different} more steps to reach goal.");
            }
        }
    }
}
