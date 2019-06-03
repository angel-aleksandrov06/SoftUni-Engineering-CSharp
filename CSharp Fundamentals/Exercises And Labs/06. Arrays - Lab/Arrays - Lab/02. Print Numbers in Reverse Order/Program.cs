using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }

            for (int k = numbers.Length - 1; k >= 0; k--)
            {
                Console.Write(numbers[k]+ " ");
            }
        }
    }
}
