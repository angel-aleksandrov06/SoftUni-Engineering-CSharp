using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                number = Math.Abs(number);
                if (number % 2 == 0)
                {
                    Console.WriteLine($"The number is: {number}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Please write an even number.");
                }

            }
        }
    }
}
