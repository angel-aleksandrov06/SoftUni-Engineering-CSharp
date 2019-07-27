using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ");

            string firstStr = command[0];
            string secondStr = command[1];

            string shortStr = string.Empty;
            string longerStr = string.Empty;
            int totalSum = 0;

            if(firstStr.Length < secondStr.Length)
            {
                shortStr = firstStr;
                longerStr = secondStr;
            }
            else
            {
                shortStr = secondStr;
                longerStr = firstStr;
            }

            for (int i = 0; i < shortStr.Length; i++)
            {
                totalSum += shortStr[i] * longerStr[i];
            }

            for (int i = shortStr.Length; i < longerStr.Length; i++)
            {
                totalSum += longerStr[i];
            }

            Console.WriteLine(totalSum);
        }
    }
}
