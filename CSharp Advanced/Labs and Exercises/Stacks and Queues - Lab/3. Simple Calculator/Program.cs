using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input.Reverse());

            while (stack.Count >1)
            {
                int first = int.Parse(stack.Pop());
                string opr = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (opr == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else if (opr == "-")
                {
                    stack.Push((first - second).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
