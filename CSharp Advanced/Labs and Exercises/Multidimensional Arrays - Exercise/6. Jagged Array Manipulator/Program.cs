using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfRows = int.Parse(Console.ReadLine());

            var jaggedArray = new double[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            Analyze(jaggedArray);

            while (true)
            {
                var commandParts = Console.ReadLine().Split();
                var command = commandParts[0];

                if (command == "End")
                {
                    break;
                }
                if (commandParts.Length != 4)
                {
                    continue;
                }

                var targetRow = int.Parse(commandParts[1]);
                var targetCol = int.Parse(commandParts[2]);
                var value = int.Parse(commandParts[3]);

                if (!isInside(jaggedArray, targetRow, targetCol))
                {
                    continue;
                }
                if (command == "Add")
                {
                    jaggedArray[targetRow][targetCol] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[targetRow][targetCol] -= value;
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool isInside(double[][] jaggedArray, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < jaggedArray.Length &&
                   targetCol >= 0 && targetCol < jaggedArray[targetRow].Length;
        }

        private static void Analyze(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length-1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row +1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                    }
                    for (int col = 0; col < jaggedArray[row+1].Length; col++)
                    {
                        jaggedArray[row+1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row+1].Length; col++)
                    {
                        jaggedArray[row+1][col] /= 2;
                    }
                }
            }
        }
    }
}
