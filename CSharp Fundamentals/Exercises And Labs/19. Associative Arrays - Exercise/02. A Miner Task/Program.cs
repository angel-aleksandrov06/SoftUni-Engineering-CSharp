using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, int> pairs = new Dictionary<string, int>();

            while (command != "stop")
            {
                string key = command;
                int value = int.Parse(Console.ReadLine());

                if (!pairs.ContainsKey(key))
                {
                    pairs[key] = value;
                }
                else
                {
                    pairs[key] += value;
                }

                command = Console.ReadLine();
            }

            foreach (var kvp in pairs)
            {
                string key = kvp.Key;
                int value = kvp.Value;

                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
