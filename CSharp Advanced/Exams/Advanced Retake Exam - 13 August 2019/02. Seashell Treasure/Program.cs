using System;
using System.Collections.Generic;

namespace _02._Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsOfTheBeach = int.Parse(Console.ReadLine());

            var beach = new char[rowsOfTheBeach][];
            var listCollectedSeashells = new List<char>();
            var stolenSeashells = 0;

            for (int i = 0; i < beach.Length; i++)
            {
                beach[i] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Sunset")
                {
                    break;
                }

                var commandParts = command.Split();

                var currentCommand = commandParts[0];
                var row = int.Parse(commandParts[1]);
                var col = int.Parse(commandParts[2]);

                if (currentCommand == "Collect" && IsIndexValid(row, col, beach) && beach[row][col] != '-')
                {
                    listCollectedSeashells.Add(beach[row][col]);
                    beach[row][col] = '-';
                }

                else if (currentCommand == "Steal")
                {
                    var direction = commandParts[3];
                    var steps = 3;

                    if (IsIndexValid(row, col, beach))
                    {
                        if (direction == "up")
                        {
                            for (int i = 0; i <= steps; i++)
                            {
                                stolenSeashells = StolenUp(row, col, beach, stolenSeashells);
                                row--;
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 0; i <= steps; i++)
                            {
                                if (IsIndexValid(row + i, col, beach) && beach[row + i][col] != '-')
                                {
                                    stolenSeashells++;
                                    beach[row + i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 0; i <= steps; i++)
                            {
                                stolenSeashells = StolenUp(row, col, beach, stolenSeashells);
                                col--;
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i <= steps; i++)
                            {
                                stolenSeashells = StolenUp(row, col, beach, stolenSeashells);
                                col++;
                            }
                        }
                    }
                }
            }

            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(' ', row));
            }

            if (listCollectedSeashells.Count != 0)
            {
                Console.WriteLine($"Collected seashells: {listCollectedSeashells.Count} -> {string.Join(", ", listCollectedSeashells)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {listCollectedSeashells.Count}");
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }

        private static int StolenUp(int row, int col, char[][] beach, int stolenSeashells)
        {
            if (IsIndexValid(row, col, beach))
            {
                var currentPosition = beach[row][col];
                if (currentPosition != '-')
                {
                    stolenSeashells++;
                    beach[row][col] = '-';
                }

            }

            return stolenSeashells;
        }

        public static bool IsIndexValid(int row, int col, char[][] matrix) =>
            (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length) ? true : false;
    }
}
