using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Sum_Matrix_Elements
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
                var rowElements = rowAsString.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(matrix.Cast<int>().Sum());
        }
    }
}
