using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentRecord = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = input[0];
                decimal studentGrade = decimal.Parse(input[1]);

                if (!studentRecord.ContainsKey(studentName))
                {
                    studentRecord.Add(studentName, new List<decimal>());
                }
                studentRecord[studentName].Add(studentGrade);
            }

            foreach (var student in studentRecord)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var studentGrades in student.Value)
                {
                    Console.Write($"{studentGrades:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
   
        }
    }
}
