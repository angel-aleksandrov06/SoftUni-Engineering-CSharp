using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] splitedInput = input
                .Split(">");

            string result = splitedInput[0];
            int remainingPower = 0;


            for (int i = 1; i < splitedInput.Length; i++)
            {
                result += ">";

                int power = int.Parse(splitedInput[i][0].ToString()) + remainingPower;

                if (power > splitedInput[i].Length)
                {
                    remainingPower = power - splitedInput[i].Length;
                }
                else
                {
                    result += splitedInput[i].Substring(power);
                }
            }

            Console.WriteLine(result);
        }
    }
}
