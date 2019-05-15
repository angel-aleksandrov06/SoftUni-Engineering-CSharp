using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            

            for(int i =0; i<n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                leftSum += num;
            }
            int rightSum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                rightSum += num;
            }
            
            if (leftSum==rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum} " );
            }
            else
            {
                int diff = Math.Abs(leftSum - rightSum);
                Console.WriteLine($"No, diff = {diff}");
            }


        }
    }
}
