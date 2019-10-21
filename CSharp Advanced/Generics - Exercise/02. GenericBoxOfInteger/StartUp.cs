using System;

namespace Generics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                var input = int.Parse(Console.ReadLine());

                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
