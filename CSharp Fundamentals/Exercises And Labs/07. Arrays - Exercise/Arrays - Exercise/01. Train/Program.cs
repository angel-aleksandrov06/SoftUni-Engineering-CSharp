using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {

            int numbersWagon = int.Parse(Console.ReadLine());
            int[] people = new int[numbersWagon];
            int sum = 0;

            for (int i = 0; i < numbersWagon; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                sum += people[i];
            }

            for (int i = 0; i < numbersWagon; i++)
            {
                Console.Write(people[i]+ " ");
            }
            Console.WriteLine();

            Console.WriteLine(sum);

        }
    }
}
