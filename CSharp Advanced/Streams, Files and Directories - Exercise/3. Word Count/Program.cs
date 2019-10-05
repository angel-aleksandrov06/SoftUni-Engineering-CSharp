using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            var words = File.ReadAllLines("words.txt").ToList();
            var inputLines = File.ReadAllLines("text.txt");
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToLower();

                if (!dict.ContainsKey(words[i]))
                {
                    dict[words[i]] = 0;
                }
                for (int k = 0; k < inputLines.Length; k++)
                {
                    inputLines[k] = inputLines[k].ToLower();
                    var splitedLine = inputLines[k].Split(new char[] { '-', ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < splitedLine.Length; j++)
                    {
                        if (splitedLine[j] == words[i])
                        {
                            dict[words[i]]++;
                        }
                    }
                }
            }

            var outputList = new List<string>();

            foreach (var kvp in dict)
            {
                outputList.Add($"{kvp.Key} - {kvp.Value}");
            }

            File.WriteAllLines("..\\..\\..\\actualResults.txt", outputList);

            var sortedDictionary = dict.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            outputList.Clear();
            foreach (var kvp in sortedDictionary)
            {
                outputList.Add($"{kvp.Key} - {kvp.Value}");
            }

            var CheckWords = File.ReadAllLines("expectedResult.txt");
            for (int i = 0; i < CheckWords.Length; i++)
            {
                if (outputList[i] == CheckWords[i])
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
            }
        }
    }
}
