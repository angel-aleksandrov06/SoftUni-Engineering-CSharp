using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizesForMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizesForMatrix, sizesForMatrix];

            for (int row = 0; row < sizesForMatrix; row++)
            {
                var inputRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizesForMatrix; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            while (true)
            {
                var commandParts = Console.ReadLine().Split();
                var command = commandParts[0];

                if (command == "END")
                {
                    break;
                }
                else if (command == "Add")
                {
                    var currentRow = int.Parse(commandParts[1]);
                    var currentCol = int.Parse(commandParts[2]);
                    int value = int.Parse(commandParts[3]);

                    bool isRowCorrect = currentRow >= 0 && currentRow < matrix.GetLength(0);
                    bool isColCorrect = currentCol >= 0 && currentCol < matrix.GetLength(1);

                    if (isRowCorrect && isColCorrect)
                    {
                        matrix[currentRow, currentCol] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if(command == "Subtract")
                {
                    var currentRow = int.Parse(commandParts[1]);
                    var currentCol = int.Parse(commandParts[2]);
                    int value = int.Parse(commandParts[3]);

                    bool isRowCorrect = currentRow >= 0 && currentRow < matrix.GetLength(0);
                    bool isColCorrect = currentCol >= 0 && currentCol < matrix.GetLength(1);

                    if (isRowCorrect && isColCorrect)
                    {
                        matrix[currentRow, currentCol] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
