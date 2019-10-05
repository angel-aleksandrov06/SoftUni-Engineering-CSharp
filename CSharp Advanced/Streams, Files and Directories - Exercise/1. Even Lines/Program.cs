using System;
using System.IO;
using System.Linq;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var streamReader = new StreamReader(@"text.txt");

            var lineCounter = 0;
            var symbolsToReplace = new[] { "-", ",", ".", "!", "?" };

            using (streamReader)
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();

                    if (lineCounter % 2 == 0)
                    {
                        var words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < words.Length; i++)
                        {
                            var currentWord = words[i];

                            foreach (var symbol in symbolsToReplace)
                            {
                                currentWord = currentWord.Replace(symbol, "@");
                            }
                            words[i] = currentWord;
                        }

                        var result = string.Join(" ", words.Reverse());
                        Console.WriteLine(result);
                    }
                    lineCounter++;
                }
            }
        }
    }
}
