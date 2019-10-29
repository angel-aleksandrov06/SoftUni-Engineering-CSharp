using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            while (true)
            {
                var commandParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandParts[0];
                var isCommandInvalid = false;

                if (command == "END")
                {
                    break;
                }
                else if (command == "swap" && commandParts.Length == 5)
                {
                    var row1 = int.Parse(commandParts[1]);
                    var col1 = int.Parse(commandParts[2]);
                    var row2 = int.Parse(commandParts[3]);
                    var col2 = int.Parse(commandParts[4]);

                    var isRowsValid = row1 >= 0 && row1 < rows && row2 >= 0 && row2 < rows;
                    var isColsValid = col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols;

                    if (isRowsValid && isColsValid)
                    {
                        var buffer1 = matrix[row1, col1];
                        var buffer2 = matrix[row2, col2];

                        matrix[row1, col1] = buffer2;
                        matrix[row2, col2] = buffer1;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row,col] + " ");
                            }
                            Console.WriteLine();
                        }
                        isCommandInvalid = true;
                    }
                }
                if (!isCommandInvalid)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
