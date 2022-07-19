using System;
using System.Linq;
using System.Collections.Generic;


namespace _06._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                string courseName = commandArgs[0];
                string studentName = commandArgs[1];

                if (!courseInfo.ContainsKey(courseName))
                {
                    courseInfo[courseName] = new List<string>();
                }

                courseInfo[courseName].Add(studentName);
            }

            PrintCoursesInfo(courseInfo);
        }

        static void PrintCoursesInfo(Dictionary<string, List<string>> courseInfo)
        {
            foreach (var keyValuePair in courseInfo)
            {
                string courseName = keyValuePair.Key;
                List<string> student = keyValuePair.Value;

                Console.WriteLine($"{courseName}: {student.Count}");

                foreach (string studentName in student)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
        
    }
}
