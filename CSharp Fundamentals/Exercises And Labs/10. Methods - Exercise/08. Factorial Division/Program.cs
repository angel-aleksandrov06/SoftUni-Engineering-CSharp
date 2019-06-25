using System;
using System.Numerics;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNumber = int.Parse(Console.ReadLine());
            BigInteger secondNumber = int.Parse(Console.ReadLine());

            BigInteger resultFirstFactorial = CalculateFactorial(firstNumber);
            BigInteger resultSecondFactorial = CalculateFactorial(secondNumber);

            DivideFactorials(resultFirstFactorial,resultSecondFactorial);
        }

        private static void DivideFactorials(BigInteger firstResult, BigInteger secondResult)
        {
            decimal div = (decimal)firstResult / (decimal)secondResult;
            
            Console.WriteLine($"{div:f2}");

        }

        private static BigInteger CalculateFactorial(BigInteger number)
        {
            BigInteger result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
