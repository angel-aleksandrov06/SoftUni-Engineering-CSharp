using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int firstResult = SmallerNumber(a, b);
            int smallestNumber = SmallerNumber(firstResult, c);

            Console.WriteLine(smallestNumber);
        }

        static int SmallerNumber(int firstnumber, int secondNumber)
        {
            if (firstnumber < secondNumber)
            {
                return firstnumber;
            }
            return secondNumber;
        }
    }
}
