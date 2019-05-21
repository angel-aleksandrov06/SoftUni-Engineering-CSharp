using System;

namespace _2._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double dolars = double.Parse(Console.ReadLine());
            double pounds = dolars * 1.31;
            Console.WriteLine($"{pounds:F3}");
        }
    }
}
