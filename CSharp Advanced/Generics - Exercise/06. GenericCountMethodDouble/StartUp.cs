using System;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var inputCount = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < inputCount; i++)
            {
                var input = double.Parse(Console.ReadLine());

                box.Values.Add(input);
            }

            var targetItem = double.Parse(Console.ReadLine());

            var result = box.GreaterValuesThan(targetItem);

            Console.WriteLine(result);
        }
    }
}
