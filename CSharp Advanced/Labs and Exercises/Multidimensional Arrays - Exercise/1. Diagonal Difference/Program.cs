using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfMatrix, sizeOfMatrix];
            var SumOfFirstDiagonal = 0;
            var SumOfSecondDiagonal = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                SumOfFirstDiagonal += inputRow[row];
                SumOfSecondDiagonal += inputRow[inputRow.Length - row -1];
            }

            var Sum = Math.Abs(SumOfFirstDiagonal - SumOfSecondDiagonal);
            Console.WriteLine(Sum);
        }
    }
}
