using System;

namespace _06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input from the user
            const double NEEDED_POINTS_FOR_OSKAR = 1250.5;

            string nameOfTheActor = Console.ReadLine();
            double pointsFromAccademy = double.Parse(Console.ReadLine());//Точки от академията
            int numberOfEvaluators = int.Parse(Console.ReadLine());//
            double sumPoints = pointsFromAccademy;

            bool isActorFound = false;

            //Logic for solving the problem
            for (int i = 0; i < numberOfEvaluators; i++)
            {
                string nameOfJury = Console.ReadLine();//Име на оценяващия актьор
                double pointsFromJury = double.Parse(Console.ReadLine());//Точки от оценяващия

                double momentPoints = (nameOfJury.Length * pointsFromJury / 2);
                sumPoints += momentPoints;

                if (sumPoints >= NEEDED_POINTS_FOR_OSKAR)
                {
                    isActorFound = true;
                    break;
                }

            }
            if (isActorFound)
            {
                Console.WriteLine($"Congratulations, {nameOfTheActor} got a nominee for leading role with {sumPoints:f1}!");
            }
            else
            {
                double neededPoins = NEEDED_POINTS_FOR_OSKAR - sumPoints;
                Console.WriteLine($"Sorry, {nameOfTheActor} you need {neededPoins:f1} more!");
            }
        }
    }
}
