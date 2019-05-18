using System;

namespace _8._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= number; i++)
            {
                counter++;
                for (int j = 1; j <= counter; j++)
                {
                    Console.Write($"{counter} ");
                }

                Console.WriteLine();
            }
        }
    }
}
