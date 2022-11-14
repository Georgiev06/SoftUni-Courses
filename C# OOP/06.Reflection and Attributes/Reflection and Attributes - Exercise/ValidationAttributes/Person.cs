using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequired]
        public string Name { get; set; }
        [MyRange(12,90)]
        public int Age { get; set; }
    }
}
