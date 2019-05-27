using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double shoes = tax*1.0 - (0.40 * tax);
            double ekip = shoes - (0.20 * shoes);
            double ball = (0.25 * ekip);
            double acsesoars = (0.20 * ball);

            double sum = shoes + ekip + ball + acsesoars+tax;
            Console.WriteLine($"{sum:F2}");
        }
    }
}
