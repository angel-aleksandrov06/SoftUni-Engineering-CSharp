using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal lenght = decimal.Parse(Console.ReadLine());
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());
            decimal volume = 0;
            decimal M = (1 / 3);

            Console.Write("Length: ");
            Console.Write("Width: ");
            Console.Write("Height: ");

            volume = (width * lenght * height )* 0.33333333333333333333333333333M;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
