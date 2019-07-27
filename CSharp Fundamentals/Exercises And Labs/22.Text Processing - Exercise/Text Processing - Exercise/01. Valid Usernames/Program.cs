using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] username = Console.ReadLine()
                .Split(", ");

            for (int i = 0; i < username.Length; i++)
            {
                string currentUsername = username[i];

                bool isLenghtValid = true;
                bool isContentValid = true;

                if (currentUsername.Length <3 || currentUsername.Length > 16)
                {
                    isLenghtValid = false;
                }

                if (!isLenghtValid)
                {
                    continue;
                }

                for (int j = 0; j < currentUsername.Length; j++)
                {
                    char currentSymbol = currentUsername[j];

                    if (!char.IsLetterOrDigit(currentSymbol) && currentSymbol != '-' && currentSymbol != '_')
                    {
                        isContentValid = false;
                        break;
                    }
                }
                
                if(isLenghtValid && isContentValid)
                {
                    Console.WriteLine(currentUsername);
                }
            }
        }
    }
}
