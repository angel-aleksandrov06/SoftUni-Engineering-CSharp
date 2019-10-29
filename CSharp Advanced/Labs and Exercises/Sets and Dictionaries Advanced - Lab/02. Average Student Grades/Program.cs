using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var grade = double.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<double>();
                }
                dict[name].Add(grade);
            }

            foreach (var kvp in dict)
            {
                var name = kvp.Key;
                var currentGrade = kvp.Value;
                var averageGrade = currentGrade.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in currentGrade)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {averageGrade:f2})");
            }
        }
    }
}
