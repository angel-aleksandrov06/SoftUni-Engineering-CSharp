using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<char>();

            var text = Console.ReadLine();

            foreach (var ch in text)
            {
                stack.Push(ch);
            }

            while (stack.Count !=0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
