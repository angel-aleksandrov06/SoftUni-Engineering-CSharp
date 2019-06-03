using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inPutNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int sum = 0;
            for (int i = 0; i < inPutNumbers.Length; i++)
            {
                if(inPutNumbers[i] % 2 == 0)
                {
                    sum += inPutNumbers[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
