using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0.0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;
            

            for (int z = 1; z <= n; z++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (z % 2 == 0)
                {

                    if (currentNumber > evenMax)
                    {
                        evenMax = currentNumber;
                    }
                    if (currentNumber < evenMin)
                    {
                        evenMin = currentNumber;
                    }
                    evenSum += currentNumber;
                }
                else
                {

                    if (currentNumber > oddMax)
                    {
                        oddMax = currentNumber;
                    }
                    if (currentNumber < oddMin)
                    {
                        oddMin = currentNumber;
                    }
                    oddSum += currentNumber;
                }
            }
            


            Console.WriteLine($"OddSum={oddSum:F2},");


                    if(oddMin == double.MaxValue)
                    {
                        Console.WriteLine($"OddMin=No,");
                    }else
                    {
                        Console.WriteLine($"OddMin={oddMin:F2},");
                    }


                    if (oddMax == double.MinValue)
                    {
                        Console.WriteLine($"OddMax=No,");
                    }
                    else
                    {
                        Console.WriteLine($"OddMax={oddMax:F2},");
                    }
                    

            Console.WriteLine($"EvenSum={evenSum:F2},");
            
                    if (evenMin == double.MaxValue)
                    {
                        Console.WriteLine($"EvenMin=No,");
                    }
                    else
                    {
                        Console.WriteLine($"EvenMin={evenMin:F2},");
                    }

                    if (evenMax == double.MinValue)
                    {
                        Console.WriteLine($"EvenMax=No");
                    }
                    else
                    {
                        Console.WriteLine($"EvenMax={evenMax:F2}");
                    }





        }
    }
}
