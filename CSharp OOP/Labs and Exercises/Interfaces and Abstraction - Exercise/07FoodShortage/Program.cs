namespace _07FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            List<IBuyer> citizens = new List<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 3)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var group = input[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    citizens.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var id = input[2];
                    var birthdate = input[3];
                    IBuyer person = new Person(name, age, id, birthdate);
                    citizens.Add(person);
                }
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var citizen in citizens)
                {
                    if (citizen.Name.Equals(command))
                    {
                        citizen.BuyFood();
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(citizens.Sum(x=>x.Food));
        }
    }
}
