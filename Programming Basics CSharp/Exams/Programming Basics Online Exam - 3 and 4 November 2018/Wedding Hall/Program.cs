using System;

namespace Wedding_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());

            double bar = a * a;
            double hall = width * lenght;
            double dencing = hall * 0.19;
            double freePlace = hall - bar - dencing;

            double countPeople = Math.Ceiling(freePlace / 3.2);

            Console.WriteLine(countPeople);
        }
    }
}
