using System;
using System.Numerics;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger[] array = new BigInteger[50];

            array[0] = 1;
            array[1] = 1;

            for (int i = 2; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            Console.WriteLine(array[n-1]);
        }
    }
}
