using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSqareMatrix = int.Parse(Console.ReadLine());

            var sum = 0;

            for (int col = 0; col < numberOfSqareMatrix; col++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                sum += input[col];
            }

            Console.WriteLine(sum);
        }
    }
}
