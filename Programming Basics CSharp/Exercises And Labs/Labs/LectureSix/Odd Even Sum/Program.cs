using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int even = 0;
            int odd = 0;
            
            for(int i=1; i<=n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    even += currentNumber;
                }
                else
                {
                    odd += currentNumber;
                }
            }
            int diff = Math.Abs(odd - even);
            if (diff ==0)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {odd}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {diff}");
            }

        }
    }
}
