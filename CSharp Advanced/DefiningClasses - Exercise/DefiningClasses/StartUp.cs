using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Family family = new Family();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }


}
