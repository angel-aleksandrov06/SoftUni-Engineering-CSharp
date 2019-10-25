using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[][] table = new string[n][];

            for (int i = 0; i < n; i++)
            {
                table[i] = Console.ReadLine().Split(", ");
            }

            var commandParts = Console.ReadLine().Split();

            var command = commandParts[0];
            var header = commandParts[1];

            var headerIndex = Array.IndexOf(table[0], header);

            if (command == "hide")
            {
                for (int row = 0; row < table.Length; row++)
                {
                    var lineToPrint = new List<string>(table[row]);

                    lineToPrint.RemoveAt(headerIndex);
                    Console.WriteLine(string.Join(" | ", lineToPrint));

                    table[row] = lineToPrint.ToArray();
                }
            }
            else if (command == "sort")
            {
                var headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                foreach (var row in table)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                var parameter = commandParts[2];
                var headerRow = table[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][headerIndex] == parameter)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
            }
        }
    }
}
