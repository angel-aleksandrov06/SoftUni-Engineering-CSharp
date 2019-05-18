using System;

namespace _2._Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand = int.Parse(Console.ReadLine());
            if (comand % 10 == 0)
            {
                Console.WriteLine($"The number is divisible by {10}");
            }
            else if (comand % 7 == 0)
            {
                Console.WriteLine($"The number is divisible by {7}");
            }
            else if (comand % 6 == 0)
            {
                Console.WriteLine($"The number is divisible by {6}");
            }
            else if (comand % 3 == 0)
            {
                Console.WriteLine($"The number is divisible by {3}");
            }
            else if (comand % 2 == 0)
            {
                Console.WriteLine($"The number is divisible by {2}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
