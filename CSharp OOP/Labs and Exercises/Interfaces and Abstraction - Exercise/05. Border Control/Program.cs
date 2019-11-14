namespace _05BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            List<ICitizen> citizens = new List<ICitizen>();

            while (command != "End")
            {
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 2)
                {
                    var model = input[0];
                    var id = input[1];
                    ICitizen robot = new Robot(model, id);
                    citizens.Add(robot);
                }
                else if (input.Length == 3)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var id = input[2];
                    ICitizen citizen = new Person(name, age, id);
                    citizens.Add(citizen);
                }

                command = Console.ReadLine();
            }

            var fakeNumber = Console.ReadLine();

            var DetainedCitizens = citizens.Where(x => x.Id.EndsWith(fakeNumber));

            foreach (var detainedCitizen in DetainedCitizens)
            {
                Console.WriteLine(detainedCitizen.Id);
            }

        }
    }
}
