using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var RowsOfGarden = int.Parse(Console.ReadLine());

            var garden = new char[RowsOfGarden][];
            var mole = 0;

            var dict = new Dictionary<char, int>();
            dict.Add('L', 0);
            dict.Add('P', 0);
            dict.Add('C', 0);

            for (int i = 0; i < RowsOfGarden; i++)
            {
                garden[i] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End of Harvest")
                {
                    break;
                }

                var CommandParts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var commandType = CommandParts[0];
                var row = int.Parse(CommandParts[1]);
                var col = int.Parse(CommandParts[2]);

                if (commandType == "Harvest")
                {
                    var isIndexValid = IsIndexValid(row, col, garden);

                    if (isIndexValid)
                    {
                        var currentItem = garden[row][col];
                        if (dict.ContainsKey(currentItem))
                        {
                            dict[currentItem]++;
                            garden[row][col] = ' ';
                        }
                    }
                }
                else if (commandType == "Mole")
                {
                    var direction = CommandParts[3];

                    if (direction == "up")
                    {
                        while (true)
                        {
                            var isIndexValid = IsIndexValid(row, col, garden);

                            if (isIndexValid)
                            {
                                var currentItem = garden[row][col];
                                if (dict.ContainsKey(currentItem))
                                {
                                    mole++;
                                    garden[row][col] = ' ';
                                }
                            }
                            else
                            {
                                break;
                            }

                            row-=2;
                        }
                    }
                    else if (direction == "down")
                    {
                        while (true)
                        {
                            var isIndexValid = IsIndexValid(row, col, garden);

                            if (isIndexValid)
                            {
                                var currentItem = garden[row][col];
                                if (dict.ContainsKey(currentItem))
                                {
                                    mole++;
                                    garden[row][col] = ' ';
                                }
                            }
                            else
                            {
                                break;
                            }

                            row+=2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (true)
                        {
                            var isIndexValid = IsIndexValid(row, col, garden);

                            if (isIndexValid)
                            {
                                var currentItem = garden[row][col];
                                if (dict.ContainsKey(currentItem))
                                {
                                    mole++;
                                    garden[row][col] = ' ';
                                }
                            }
                            else
                            {
                                break;
                            }

                            col-=2;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (true)
                        {
                            var isIndexValid = IsIndexValid(row, col, garden);

                            if (isIndexValid)
                            {
                                var currentItem = garden[row][col];
                                if (dict.ContainsKey(currentItem))
                                {
                                    mole++;
                                    garden[row][col] = ' ';
                                }
                            }
                            else
                            {
                                break;
                            }

                            col+=2;
                        }
                    }
                }
            }

            for (int i = 0; i < RowsOfGarden; i++)
            {
                    Console.WriteLine(string.Join(" ", garden[i]));
            }

            Console.WriteLine($"Carrots: {dict['C']}");
            Console.WriteLine($"Potatoes: {dict['P']}");
            Console.WriteLine($"Lettuce: {dict['L']}");
            Console.WriteLine($"Harmed vegetables: {mole}");
        }
        public static bool IsIndexValid(int row, int col, char[][] matrix) =>
            (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length) ? true : false;
    }
}
