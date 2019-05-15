using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());
            double commission = 0;

            if (town == "Sofia")
            {
                if (sells >= 0 && sells <= 500)
                {
                    commission = 0.05;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 500 && sells <= 1000)
                {
                    commission = 0.07;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 1000 && sells <= 10000)
                {
                    commission = 0.08;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 10000)
                {
                    commission = 0.12;
                    Console.WriteLine($"{ sells * commission:F2}");

                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "Varna")
            {
                if (sells >= 0 && sells <= 500)
                {
                    commission = 0.045;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 500 && sells <= 1000)
                {
                    commission = 0.075;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 1000 && sells <= 10000)
                {
                    commission = 0.10;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 10000)
                {
                    commission = 0.13;
                    Console.WriteLine($"{ sells * commission:F2}");

                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (town == "Plovdiv")
            {
                if (sells >= 0 && sells <= 500)
                {
                    commission = 0.055;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 500 && sells <= 1000)
                {
                    commission = 0.08;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 1000 && sells <= 10000)
                {
                    commission = 0.12;
                    Console.WriteLine($"{ sells * commission:F2}");
                }
                else if (sells > 10000)
                {
                    commission = 0.145;
                    Console.WriteLine($"{ sells * commission:F2}");

                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
