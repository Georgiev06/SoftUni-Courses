using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> student = new List<Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                student.Add(new Student(input[0], int.Parse(input[1])));
            }

            string filterInput = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();

            Func<Student, int, bool> filter = GetFilter(filterInput);

            student = student.Where(x => filter(x, ageFilter)).ToList();

            Action<Student> printStudent = GetPrinter(formatInput);

            student.ForEach(printStudent);
        }

        private static Action<Student> GetPrinter(string formatInput)
        {
            switch (formatInput)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);
                case "age":
                    return a => Console.WriteLine(a.Age);
                case "name age":
                    return x => Console.WriteLine($"{x.Name} - {x.Age}");
                default:
                    return null;
            }
        }

        private static Func<Student, int, bool> GetFilter(string filterInput)
        {
            switch (filterInput)
            {
                case "older":
                    return (s, age) => s.Age >= age;
                case "younger":
                    return (s, age) => s.Age < age;
                default:
                    return null;
            }
        }
    }

    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
