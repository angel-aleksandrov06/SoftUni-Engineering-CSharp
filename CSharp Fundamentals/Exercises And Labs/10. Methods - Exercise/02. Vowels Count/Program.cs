using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();
            VowelsCount(word);
        }

        static void VowelsCount(string word)
        {
            int vowelsCount = 0;

            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    vowelsCount++;
                }
            }

            Console.WriteLine(vowelsCount);
        }
    }
}
