using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Animal_Sanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var pattern = @"^n:([^;]+);t:([^;]+);c--([A-Za-z' ']+)$";

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    var message = match.ToString().Split(";");

                    var animalName = message[0];
                    var animalKind = message[1];
                    var country = message[2].Substring(3);

                    var sb = new StringBuilder();

                    for (int j = 0; j < animalName.Length; j++)
                    {
                        if (char.IsLetter(animalName[j]) || animalName[j] == ' ')
                        {
                            sb.Append(animalName[j]);
                        }

                        if (char.IsDigit(animalName[j]))
                        {
                            totalSum += int.Parse(animalName[j].ToString());
                        }
                    }

                    animalName = sb.ToString();
                    animalName = animalName.Substring(1);
                    sb.Clear();

                    for (int j = 0; j < animalKind.Length; j++)
                    {
                        if (char.IsLetter(animalKind[j]) || animalKind[j] == ' ')
                        {
                            sb.Append(animalKind[j]);
                        }
                        if (char.IsDigit(animalKind[j]))
                        {
                            totalSum += int.Parse(animalKind[j].ToString());
                        }
                    }

                    animalKind = sb.ToString();
                    animalKind = animalKind.Substring(1);

                    Console.WriteLine($"{animalName} is a {animalKind} from {country}");

                }
            }
            Console.WriteLine($"Total weight of animals: {totalSum}KG");
        }
    }
}
