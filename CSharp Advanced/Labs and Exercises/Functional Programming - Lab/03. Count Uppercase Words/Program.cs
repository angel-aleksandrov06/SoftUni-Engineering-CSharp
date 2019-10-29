using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var filteredWords = input.Where(x=>char.IsUpper(x[0]));

            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
