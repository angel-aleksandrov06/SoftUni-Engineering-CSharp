using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
namespace Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^(?<emoji>:(?<emojiValue>[a-z]{4,}):)$";
            var text = Console.ReadLine().Split(" ");
            var inputEmojis = Console.ReadLine().Split(":").ToList();

            var list = new List<string>();
            var clearNamesOfEmojies = new List<string>();
            int totalSum = 0;

            foreach (var currentEmoji in text)
            {
                if (currentEmoji.Contains(",") || currentEmoji.Contains("!") || currentEmoji.Contains("?") || currentEmoji.Contains("."))
                {
                    pattern = @"^(?<emoji>:(?<emojiValue>[a-z]{4,}):)(,|\.|!|\?)$";
                }

                Match match = Regex.Match(currentEmoji, pattern);

                if (match.Success)
                {
                    string valueOfEmoji = match.Groups["emoji"].Value;

                    foreach (var symbol in valueOfEmoji)
                    {
                        if (symbol != ':')
                        {
                            totalSum += symbol;
                        }
                    }

                    clearNamesOfEmojies.Add(valueOfEmoji);
                }

                pattern = @"^(?<emoji>:(?<emojiValue>[a-z]{4,}):)$";
            }

            string emojiNameFromInput = ":";
            foreach (var item in inputEmojis)
            {
                char name = (char)int.Parse(item);
                emojiNameFromInput += name;
            }
            emojiNameFromInput += ":";

            if (clearNamesOfEmojies.Contains(emojiNameFromInput))
            {
                totalSum *= 2;
            }

            if (clearNamesOfEmojies.Any())
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", clearNamesOfEmojies)}");
            }

            Console.WriteLine($"Total Emoji Power: {totalSum}");
        }
    }
}
