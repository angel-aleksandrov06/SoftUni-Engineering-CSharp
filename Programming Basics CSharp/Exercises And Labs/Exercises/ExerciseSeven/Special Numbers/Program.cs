using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    for (int k = 1; k < 9; k++)
                    {
                        for (int x = 1; x < 9; x++)
                        {
                            bool first = number % i == 0;
                            bool second = number % j == 0;
                            bool third = number % k == 0;
                            bool fourth = number % x == 0;

                            if (first && second && third && fourth)
                            {
                                Console.Write($"{i}{j}{k}{x} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
