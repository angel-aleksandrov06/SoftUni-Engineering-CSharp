using System;
using System.Text;
using System.Linq;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (i == input.Length - 1)
                {
                    sb.Append(input[i]);
                }
                else
                {
                    if (symbol != input[i + 1])
                    {
                        sb.Append(input[i]);
                    }
                }

            }

            Console.WriteLine(sb);
        }
    }
}
