using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char lastCharacter = char.Parse(Console.ReadLine());

            PrintInterceptFromCharacters(firstCharacter, lastCharacter);
        }

        private static void PrintInterceptFromCharacters(char firstCharacter, char lastCharacter)
        {
            int start = (int)firstCharacter;
            int end = (int)lastCharacter;

            if (start < end)
            {
                for (int i = start + 1; i < end; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = end + 1; i < start; i++)
                {
                    Console.Write((char)i + " ");
                }
            }

        }
    }
}
