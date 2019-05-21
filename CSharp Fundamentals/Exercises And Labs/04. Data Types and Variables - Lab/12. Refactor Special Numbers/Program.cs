using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand = int.Parse(Console.ReadLine());
            bool special = false;
            int temp = 0;
            int sum = 0;
            
            for (int i = 1; i <= comand; i++)
            {
                temp = i;
                while (temp > 0)
                {
                    sum += (temp % 10);
                    temp = temp / 10;
                }
                special = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {special}");
                sum = 0;
            }

        }
    }
}
