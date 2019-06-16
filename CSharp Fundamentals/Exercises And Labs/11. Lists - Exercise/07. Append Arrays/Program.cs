using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allNumbers = Console.ReadLine().Split("|").ToList();
            List<string> splitedNumbers = new List<string>();

            for (int i = allNumbers.Count - 1; i >= 0; i--)
            {
                string[] arrCurrentNumbers = allNumbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < arrCurrentNumbers.Length; j++)
                {
                    splitedNumbers.Add(arrCurrentNumbers[j]);
                }
            }

            Console.WriteLine(string.Join(" ", splitedNumbers));
        }
    }
}
