using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(dimentions[0]);
            var cols = int.Parse(dimentions[1]);
            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var rowAsString = Console.ReadLine();
                var rowElements = rowAsString.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var sumOfColumn = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfColumn += matrix[row, col];
                }

                Console.WriteLine(sumOfColumn);
            }

        }
    }
}
