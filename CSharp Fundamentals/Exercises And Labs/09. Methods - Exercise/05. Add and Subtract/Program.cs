using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int resultSum = Sum(firstNumber, secondNumber);
            int resultSubstract = Substract(resultSum, thirdNumber);

            Console.WriteLine(resultSubstract);
        }

        private static int Substract(int resultSum, int thirdNumber)
        {
            int substract = resultSum - thirdNumber;
            return substract;
        }

        private static int Sum(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }
    }
}
