using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int comand = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            int sum = 0;

            if(start <= 10)
            {
                for (int i = start; i <= 10; i++)
                {
                    sum = comand * i;
                    Console.WriteLine($"{comand} X {i} = {sum}");
                }
            }
            else
            {
                sum = start * comand;
                Console.WriteLine($"{comand} X {start} = {sum}");
            }





            
        }
    }
}
