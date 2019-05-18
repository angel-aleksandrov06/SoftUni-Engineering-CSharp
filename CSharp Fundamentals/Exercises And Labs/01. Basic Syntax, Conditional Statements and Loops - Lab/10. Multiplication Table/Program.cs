using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= 10; i++)
            {
                sum = comand * i;
                Console.WriteLine($"{comand} X {i} = {sum}");
            }
        }
    }
}
