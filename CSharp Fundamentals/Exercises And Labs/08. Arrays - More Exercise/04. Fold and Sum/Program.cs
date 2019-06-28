using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int lenghtOfArray = array.Length;

            int leftFoldIndex = array.Length / 4 - 1;
            int rightFoldIndex = 3 * array.Length / 4;

            int[] firstArray = new int[array.Length/2];

            int numberSoFar = 0;

            for (int i = leftFoldIndex; i >= 0; i--)
            {
                numberSoFar++;
                firstArray[leftFoldIndex - i] = array[i];
            }

            for (int i = array.Length - 1; i >= rightFoldIndex; i--)
            {
                firstArray[array.Length - 1 - i + numberSoFar] = array[i];
            }

            int[] secondArray = new int[array.Length / 2];

            for (int i = leftFoldIndex+1; i < rightFoldIndex; i++)
            {
                secondArray[i-numberSoFar] = array[i];
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write(firstArray[i] + secondArray[i] + " ");
            }

        }
    }
}
