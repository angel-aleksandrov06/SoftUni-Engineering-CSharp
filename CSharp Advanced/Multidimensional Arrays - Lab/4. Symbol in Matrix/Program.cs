using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSquareMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[numberOfSquareMatrix, numberOfSquareMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            var theSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == theSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{theSymbol} does not occur in the matrix ");

        }
    }
}
