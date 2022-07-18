using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] studentsArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string studentFirstName = studentsArgs[0];
                string studentLasttName = studentsArgs[1];
                double grades = double.Parse(studentsArgs[2]);

                Student currentStudent = new Student(studentFirstName, studentLasttName, grades);

                students.Add(currentStudent);

            }

            List<Student> orderedStudentByGrades = students.OrderByDescending(s => s.Grade).ToList();

            foreach (var student in orderedStudentByGrades)
            {
                Console.WriteLine(student);
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;               
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }

    }
}
