using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand = int.Parse(Console.ReadLine());

            PrintMatrix(comand);
        }

        private static void PrintMatrix(int comand)
        {
            for (int i = 0; i < comand; i++)
            {
                for (int j = 0; j < comand; j++)
                {
                    Console.Write(comand +" ");
                }
                Console.WriteLine();
            }
        }
    }
}
