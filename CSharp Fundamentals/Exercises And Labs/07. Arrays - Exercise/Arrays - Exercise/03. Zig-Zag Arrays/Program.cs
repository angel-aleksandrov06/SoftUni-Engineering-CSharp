using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numberOdd = new int[n];
            int[] numberEven = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] comand = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    numberOdd[i] += comand[0];
                    numberEven[i] += comand[1];
                }
                else
                {
                    numberOdd[i] += comand[1];
                    numberEven[i] += comand[0];
                }
            }

            for (int j = 0; j < numberOdd.Length; j++)
            {
                Console.Write(numberOdd[j]+ " ");
            }
            Console.WriteLine();
            for (int k = 0; k < numberEven.Length; k++)
            {
                Console.Write(numberEven[k]+" ");
            }
        }
    }
}
