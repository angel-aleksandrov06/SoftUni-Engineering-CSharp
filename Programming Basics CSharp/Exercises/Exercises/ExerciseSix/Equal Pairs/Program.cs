using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int prevSum = 0;
            int diffSum = 0;
            double maxDiff = int.MinValue;
            

            for(int i =1; i<=n; i++)
            {
                prevSum = sum;

                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());

                sum = number1 + number2;
                if (i > 1)
                {
                    diffSum = prevSum-sum;
                    double diffsumABS = Math.Abs(diffSum);
                    if (diffsumABS > maxDiff)
                    {
                        maxDiff = diffsumABS;
                    }
                }
                
                
            }

            if (diffSum == 0)
            {
                Console.WriteLine($"Yes, value={sum}");

            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }


    }
}
