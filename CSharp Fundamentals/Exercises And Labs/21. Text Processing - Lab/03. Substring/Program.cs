using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine();

            var index = input.IndexOf(word);

            while (index != -1)
            {
                input = input.Remove(index, word.Length);

                index = input.IndexOf(word);
            }
            Console.WriteLine(input);
        }
    }
}
