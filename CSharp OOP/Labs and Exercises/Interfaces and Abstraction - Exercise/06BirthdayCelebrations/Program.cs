namespace _06BirthdayCelebrations
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
                var citizenType = input[0];

                if (citizenType == "Robot")
                {
                    var model = input[1];
                    var id = input[2];
                    ICitizen robot = new Robot(model, id);
                    citizens.Add(robot);
                }
                else if (citizenType == "Citizen")
                {
                    var name = input[1];
                    var age = int.Parse(input[2]);
                    var id = input[3];
                    var birthdate = input[4];
                    ICitizen citizen = new Person(name, age, id, birthdate);
                    citizens.Add(citizen);
                }
                else if (citizenType == "Pet")
                {
                    var name = input[1];
                    var birthdate = input[2];
                    ICitizen citizen = new Pet(name, birthdate);
                    citizens.Add(citizen);
                }

                command = Console.ReadLine();
            }

            var specificYear = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.Birthdate == null)
                {
                    continue;
                }
                else
                {
                    if (citizen.Birthdate.EndsWith(specificYear))
                    {
                        Console.WriteLine(citizen.Birthdate);
                    }
                }
            }
        }
    }
}
