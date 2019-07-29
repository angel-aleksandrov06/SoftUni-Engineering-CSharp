using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                sb.Append((char)(input[i] + 3));
            }

            Console.WriteLine(sb);
        }
    }
}
