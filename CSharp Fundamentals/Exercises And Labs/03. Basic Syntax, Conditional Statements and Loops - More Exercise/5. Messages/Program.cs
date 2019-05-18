using System;

namespace _5._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 1; i <= n; i++)
            {
                string number = Console.ReadLine();

                int numberOfDigits = number.Length;
                int mainDigit = int.Parse(number) % 10;
                int offset = 0;


                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset = (mainDigit - 2) * 3;
                    offset++;
                }
                else
                {
                    offset = (mainDigit - 2) * 3;
                }

                int letterIndex = (offset + numberOfDigits - 1);

                int letterCode = letterIndex + 97;

                char letter = (char)letterCode;
                if (mainDigit == 0)
                {
                    letter = (char)(mainDigit + 32);
                }

                message += letter;
            }
            Console.WriteLine(message);
        }
    }
}
