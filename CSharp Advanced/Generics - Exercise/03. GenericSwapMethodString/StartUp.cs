using System;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var inputCount = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < inputCount; i++)
            {
                var input = Console.ReadLine();

                box.Values.Add(input);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var a = indexes[0];
            var b = indexes[1];

            box.Swap(a, b);

            Console.WriteLine(box);
        }
    }
}
