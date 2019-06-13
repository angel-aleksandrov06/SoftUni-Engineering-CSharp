using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            TakeTheMiddleCharacter(word);
        }

        private static void TakeTheMiddleCharacter(string word)
        {
            int lengthOfTheString = word.Length;

            if (lengthOfTheString % 2 == 0)
            {
                int middleChar = lengthOfTheString / 2;
                Console.Write($"{word[middleChar-1]}{word[middleChar]}");
            }
            else if (lengthOfTheString%2 == 1)
            {
                int midleChar = (int)Math.Ceiling(lengthOfTheString*1.0 / 2);
                Console.WriteLine(word[midleChar-1]);
            }
        }
    }
}
