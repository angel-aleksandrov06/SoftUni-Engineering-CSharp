using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");

            var sb = new StringBuilder();

            foreach (var item in input)
            {
                int count = item.Length;

                for (int i = 0; i < count; i++)
                {
                    sb.Append(item);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
