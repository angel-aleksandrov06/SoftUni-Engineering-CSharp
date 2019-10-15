using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfPeopleOver30 = new List<Person>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                listOfPeopleOver30.Add(person);
            }

            var sortedListOfPeopleOver30 = listOfPeopleOver30.Where(x => x.Age > 30).OrderBy(x => x.Name);

            foreach (var person in sortedListOfPeopleOver30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }


}
