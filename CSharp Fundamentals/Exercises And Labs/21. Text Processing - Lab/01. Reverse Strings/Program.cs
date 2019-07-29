using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input !="end")
            {
                var reversed = "";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                Console.WriteLine($"{input} = {reversed}");

                input = Console.ReadLine();
            }
        }
    }
}
