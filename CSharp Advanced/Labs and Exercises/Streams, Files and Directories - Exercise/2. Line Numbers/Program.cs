using System;
using System.IO;
using System.Text;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var letterCounter = 0;
            var punctuationCounter = 0;

            var inputLines = File.ReadAllLines("text.txt");
            var ChangedLines = new string[inputLines.Length];

            for (int i = 0; i < inputLines.Length; i++)
            {
                foreach (var ch in inputLines[i])
                {
                    if (char.IsLetter(ch))
                    {
                        letterCounter++;
                    }
                    else if (char.IsPunctuation(ch))
                    {
                        punctuationCounter++;
                    }
                }
                ChangedLines[i] = $"Line {i+1}: {inputLines[i]} ({letterCounter})({punctuationCounter})";
                letterCounter = 0;
                punctuationCounter = 0;
            }

            File.WriteAllLines("..\\..\\..\\output.txt", ChangedLines);
        }
    }
}
