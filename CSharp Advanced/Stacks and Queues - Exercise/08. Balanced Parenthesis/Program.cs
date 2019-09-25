using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            if (expression.Length % 2 !=0)
            {
                Console.WriteLine("NO");
                return;
            }

            var openingBrackets = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(' || ch == '[' || ch =='{')
                {
                    openingBrackets.Push(ch);
                }
                else
                {
                    char lastOpeningBracket = openingBrackets.Pop();

                    if (lastOpeningBracket == '(' && ch !=')')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    if (lastOpeningBracket == '{' && ch != '}')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    if (lastOpeningBracket == '[' && ch != ']')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (openingBrackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
