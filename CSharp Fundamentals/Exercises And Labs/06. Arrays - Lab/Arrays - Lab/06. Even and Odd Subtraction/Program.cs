using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int evenSum =0;
            int oddSum =0;

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if(inputNumbers[i] % 2 == 0)
                {
                    evenSum += inputNumbers[i];
                }
                else
                {
                    oddSum += inputNumbers[i];
                }
            }
            int diference = evenSum - oddSum;
            Console.WriteLine(diference);
        }
    }
}
