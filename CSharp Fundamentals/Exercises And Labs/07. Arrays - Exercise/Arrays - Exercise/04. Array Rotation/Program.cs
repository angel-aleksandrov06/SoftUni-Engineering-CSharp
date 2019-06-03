using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int counter = n;
            for (int i = 0; i < numbers.Length; i++)
            {
                
                if(counter > numbers.Length)
                {
                    counter = n - numbers.Length;
                }
                else if (counter == numbers.Length)
                {
                    counter = 0;
                }
                Console.Write(numbers[counter] +" ");
                counter++;
            }
        }
    }
}
