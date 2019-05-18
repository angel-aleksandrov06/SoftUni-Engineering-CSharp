using System;

namespace _1._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand = int.Parse(Console.ReadLine());

            if(comand>=0 && comand <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (comand >= 3 && comand <= 13)
            {
                Console.WriteLine("child");
            }
            else if (comand >= 14 && comand <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (comand >= 20 && comand <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (comand >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
