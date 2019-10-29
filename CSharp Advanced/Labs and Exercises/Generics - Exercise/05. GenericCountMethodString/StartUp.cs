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

            var targetItem = Console.ReadLine();

            var result = box.GreaterValuesThan(targetItem);

            Console.WriteLine(result);
        }
    }
}
