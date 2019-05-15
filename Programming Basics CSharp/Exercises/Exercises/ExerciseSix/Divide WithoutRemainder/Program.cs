﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide_WithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i =1; i<=n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number%2==0)
                {
                    p1++;
                }

                if (number%3 == 0)
                {
                    p2++;
                }
                if (number % 4 == 0)
                {
                    p3++;
                }


            }



            Console.WriteLine($"{p1*1.0 / n * 100:F2}%");
            Console.WriteLine($"{p2*1.0 / n * 100:F2}%");
            Console.WriteLine($"{p3*1.0 / n * 100:F2}%");


        }
    }
}
