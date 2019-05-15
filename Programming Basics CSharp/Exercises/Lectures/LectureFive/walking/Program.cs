using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsSum = 0;
            while (true)
            {
                int stepsTarget = 10000;
                string input = Console.ReadLine(); // number || Going home
                if (input == "Going home")
                {
                    int lastSteps = int.Parse(Console.ReadLine()); // steps to home
                    stepsSum += lastSteps;
                    
                    if (stepsSum>=stepsTarget)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        int stepsLeft = stepsTarget - stepsSum;
                        Console.WriteLine($"{stepsLeft} more steps to reach goal.");
                        break;
                    }
                }
                int currentSteps = int.Parse(input);
                stepsSum += currentSteps;

                
                if (stepsSum>=stepsTarget)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    break;
                }

            }




        }
    }
}
