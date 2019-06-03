using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int comand = int.Parse(Console.ReadLine());

            if(comand>=1 && comand <= 7)
            {
                Console.WriteLine(days[comand-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

        }
    }
}
