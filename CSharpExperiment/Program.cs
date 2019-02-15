using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection;
using PhoneNumbers;

namespace CSharpExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person("person1", "person1@company.com", 1);
            
            var person2 = person1.CopyWith(
                (p => p.Name, "person2"),
                (p => p.Age, 2)
            );

            var person3 = person1.CopyWith(
                (p => p.Name, "person3"),
                (p => p.Email, "person3@company.com")
            );
            
            var person4 = person1.CopyWith(
                (p => p.Name, "person4"),
                (p => p.Age, 4),
                (p => p.Email, "person4@company.com")
            );
            
            
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            Console.WriteLine(person4);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        
        public Person(){}

        public Person(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age;
        }

        public override string ToString()
        {
            return $"Hello I'm {Name}({Age}), my email is... {Email} hc: {GetHashCode()}";
        }
    }
}