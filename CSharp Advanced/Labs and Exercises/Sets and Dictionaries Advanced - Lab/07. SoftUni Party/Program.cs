using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var regular = new HashSet<string>();
            var vip = new HashSet<string>();

            while (true)
            {
                if (command == "PARTY" || command == "END")
                {
                    break;
                }

                if (char.IsDigit(command[0]))
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }
                command = Console.ReadLine();
            }

            if (command == "PARTY")
            {
                command = Console.ReadLine();

                while (command != "END")
                {
                    if (regular.Contains(command))
                    {
                        regular.Remove(command);
                    }
                    else if (vip.Contains(command))
                    {
                        vip.Remove(command);
                    }

                    command = Console.ReadLine();
                }
            }

            Console.WriteLine(regular.Count + vip.Count);

            foreach (var number in vip)
            {
                Console.WriteLine(number);
            }
            foreach (var number in regular)
            {
                Console.WriteLine(number);
            }
        }
    }
}
