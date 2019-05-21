using System;

namespace _3._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int circle = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < circle; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine($"{sum}");
            
            
        }
    }
}
