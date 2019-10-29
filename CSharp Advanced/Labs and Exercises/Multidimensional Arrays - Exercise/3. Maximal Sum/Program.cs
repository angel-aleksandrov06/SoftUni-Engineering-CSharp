using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            var matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int subMatrixRows = 3;
            int subMatrixCols = 3;

            if (matrix.GetLength(0) < subMatrixRows || matrix.GetLength(1) < subMatrixCols)
            {
                Console.WriteLine("No solution!");
                return;
            }

            int maxSum = int.MinValue;
            int maxSumRow = -1;
            int maxSumCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - subMatrixRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subMatrixCols + 1; col++)
                {
                    var subMatrixSum = 0;

                    for (int subRow = 0; subRow < subMatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCols; subCol++)
                        {
                            subMatrixSum += matrix[row + subRow, col + subCol];
                        }
                    }

                    if (subMatrixSum > maxSum)
                    {
                        maxSum = subMatrixSum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < subMatrixRows; row++)
            {
                for (int col = 0; col < subMatrixCols; col++)
                {
                    Console.Write(matrix[maxSumRow + row, maxSumCol + col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
