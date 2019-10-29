﻿using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = items => Console.WriteLine(string.Join(Environment.NewLine, items));

            var inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print(inputNames);
        }
    }
}
