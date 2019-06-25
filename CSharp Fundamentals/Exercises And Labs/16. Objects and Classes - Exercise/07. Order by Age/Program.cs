using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitedInput = command.Split(" ");

                string name = splitedInput[0];
                string id = splitedInput[1];
                int age = int.Parse(splitedInput[2]);

                Person person = new Person(name, id,age);

                people.Add(person);

                command = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person (string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
}
