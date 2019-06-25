using System;

namespace _04._Password_Validator
{
    class Program
    {
        public static bool CheckingComandIsOnlyLettersAndDigits { get; private set; }

        static void Main(string[] args)
        {
            string inputComand = Console.ReadLine();

            bool checkLengthOfComand = CheckingLengthOfComand(inputComand);
            bool areSymbolsValid = ArreSybolsValid(inputComand); ;
            bool isThereAtLeastTwoDigits = IsThereAtLeastTwoDigits(inputComand); ;

            PrintOptions(checkLengthOfComand, areSymbolsValid, isThereAtLeastTwoDigits);
        }

        private static void PrintOptions(bool checkLengthOfComand, bool areSymbolsValid, bool isThereAtLeastTwoDigits)
        {
            if (!checkLengthOfComand)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!areSymbolsValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isThereAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if(checkLengthOfComand && areSymbolsValid && isThereAtLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool IsThereAtLeastTwoDigits(string inputComand)
        {
            int counter = 0;
            for (int i = 0; i < inputComand.Length; i++)
            {
                if (char.IsDigit(inputComand[i]))
                {
                    counter++;
                }
                if (counter >= 2)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ArreSybolsValid(string inputComand)
        {
            for (int i = 0; i < inputComand.Length; i++)
            {
                if (!char.IsLetterOrDigit(inputComand[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckingLengthOfComand(string inputComand)
        {
            if (inputComand.Length <= 10 && inputComand.Length >= 6)
            {
                return true;
            }
            return false;
        }
    }
}
