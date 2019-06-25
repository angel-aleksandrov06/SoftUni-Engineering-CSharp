using System;
using System.Linq;
using System.Numerics;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            

            while (comand!="END")
            {
                bool isComandIntereg = CheckIsItOnlyDigits(comand);

                if (isComandIntereg)
                {
                    ChekingPalindromeIntegers(comand);
                }
                
                comand = Console.ReadLine();
            }
        }

        private static bool CheckIsItOnlyDigits(string comand)
        {
            for (int i = 0; i < comand.Length; i++)
            {
                if (!char.IsDigit(comand[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void ChekingPalindromeIntegers(string comand)
        {
            string newString = string.Empty;

            for (int i = 0; i < comand.Length; i++)
            {
                newString += comand[comand.Length-1-i];
            }
            

            if(comand == newString)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
