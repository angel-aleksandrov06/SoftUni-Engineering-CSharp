using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var ch = input[i];

                if (ch == '(')
                {
                    stack.Push(i);
                }
                else if (ch == ')')
                {
                    var leftIndex = stack.Pop();
                    var rightIndex = i;
                    var expression = input.Substring(leftIndex, rightIndex - leftIndex + 1);
                    Console.WriteLine(expression);
                }
            }
        }
    }
}
