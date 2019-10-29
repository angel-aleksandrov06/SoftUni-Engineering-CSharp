using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());

            long[][] pascalArray = new long[rows][];
            int currentWidth = 1;

            for (int row = 0; row < rows; row++)
            {
                pascalArray[row] = new long[currentWidth];
                long[] currentRow = pascalArray[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int col = 1; col < currentRow.Length -1 ; col++)
                    {
                        long[] previousRow = pascalArray[row - 1];
                        var previousRowSum = previousRow[col] + previousRow[col - 1];
                        currentRow[col] = previousRowSum;
                    }
                }
            }

            foreach (var row in pascalArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
