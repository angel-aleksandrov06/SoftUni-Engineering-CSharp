using System;
using System.Text;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ");

            var text = Console.ReadLine();

            var sb = new StringBuilder();

            foreach (var item in input)
            {
                if (text.Contains(item))
                {
                    text = text.Replace(item, new string('*', item.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
