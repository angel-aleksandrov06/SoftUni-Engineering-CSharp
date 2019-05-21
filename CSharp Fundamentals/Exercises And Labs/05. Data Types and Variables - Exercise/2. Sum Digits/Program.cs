using System;

namespace _2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int sum = 0;
            int number = int.Parse(comand);


            for (int i = 1; i <= comand.Length; i++)
            {
                
                int singelNumber = number % 10;
                number = number / 10;
                sum += singelNumber;

            }
            Console.WriteLine(sum);
        }
    }
}
