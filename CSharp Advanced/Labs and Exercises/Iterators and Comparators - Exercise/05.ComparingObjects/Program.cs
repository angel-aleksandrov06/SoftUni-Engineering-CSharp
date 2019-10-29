using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new List<Person>();

            var command = Console.ReadLine();

            while (command != "END")
            {
                var personInfo = command.Split().ToArray();

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var town = personInfo[2];

                var person = new Person(name, age, town);

                people.Add(person);

                command = Console.ReadLine();
            }

            var n = int.Parse(Console.ReadLine());

            var targetPerson = people[n - 1];

            var matches = 1;

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0 && !person.Equals(targetPerson))
                {
                    matches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count-matches} {people.Count}");
            }
        }
    }
}
