using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }

                dict[name].Add(grade);
            }

            var newDict = dict.Where(x => x.Value.Sum()/x.Value.Count >= 4.50);

            foreach (var item in newDict.OrderByDescending(x => x.Value.Sum() / x.Value.Count))
            {
                var averageGrade = item.Value.Sum() / item.Value.Count();
                Console.WriteLine($"{item.Key} -> {averageGrade:f2}");
            }
        }
    }
}
