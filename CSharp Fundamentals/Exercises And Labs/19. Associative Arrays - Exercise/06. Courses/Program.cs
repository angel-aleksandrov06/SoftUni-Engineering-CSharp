using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dict = new Dictionary<string,List<string>>();

            while (input != "end")
            {
                var splitedInput = input.Split(" : ");
                var courseName = splitedInput[0];
                var studentName = splitedInput[1];

                if (!dict.ContainsKey(courseName))
                {
                    dict.Add(courseName, new List<string>());
                }

                dict[courseName].Add(studentName);

                input = Console.ReadLine();
            }


            foreach (var item in dict.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var name in item.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
