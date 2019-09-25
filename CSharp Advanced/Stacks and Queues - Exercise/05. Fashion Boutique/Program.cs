using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int numbersOfClothes = stack.Count();

            int capacityOfOneRack = int.Parse(Console.ReadLine());
            int sum = 0;
            int numberOfRacks = 0;

            for (int i = 0; i < numbersOfClothes; i++)
            {
                if (i==0)
                {
                    numberOfRacks++;
                }

                int currentClothes = stack.Pop();
                sum += currentClothes;

                if (sum > capacityOfOneRack )
                {
                    sum = currentClothes;
                    numberOfRacks++;
                }
                
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
