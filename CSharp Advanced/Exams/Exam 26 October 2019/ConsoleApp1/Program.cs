using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var male = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var famale = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var match = 0;

            while (male.Count > 0 && famale.Count >0)
            {
                var peekMale = male.Peek();
                var peekFemale = famale.Peek();

                if (peekFemale <= 0)
                {
                    famale.Dequeue();
                    continue;
                }
                if (peekMale <= 0)
                {
                    male.Pop();
                    continue;
                }

                if (peekMale %25 ==0)
                {
                    male.Pop();
                    male.Pop();
                    continue;
                }
                if (peekFemale %25 ==0)
                {
                    famale.Dequeue();
                    famale.Dequeue();
                    continue;
                }

                if (peekMale == peekFemale)
                {
                    male.Pop();
                    famale.Dequeue();
                    match++;
                    continue;
                }
                else
                {
                    famale.Dequeue();
                    var currentMale = male.Pop();
                    currentMale -= 2;
                    male.Push(currentMale);
                }
            }

            Console.WriteLine($"Matches: {match}");

            if (male.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", male)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (famale.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", famale)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
