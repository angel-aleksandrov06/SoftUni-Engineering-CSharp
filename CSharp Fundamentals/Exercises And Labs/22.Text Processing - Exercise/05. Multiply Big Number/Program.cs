using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            int onMind = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int currentMultiplier = int.Parse(numbers[i].ToString());

                int result = currentMultiplier * number + onMind;

                sb.Append(result % 10 );

                onMind = result / 10;
            }

            if (onMind != 0)
            {
                sb.Append(onMind);
            }

            var resulstNumber = string.Join("", sb.ToString().Reverse()).TrimStart('0');

            if (resulstNumber== string.Empty)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(resulstNumber);
            }

        }
    }
}
