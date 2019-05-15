using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace halfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumber = int.MinValue;
            for(int i =0; i<n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if (number>maxNumber)
                {
                    maxNumber = number;
                }
            }

            if(maxNumber == sum - maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " +maxNumber);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + Math.Abs(maxNumber-(sum-maxNumber)));
            }


        }
    }
}
