using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int> addFunc = num => num += 1;
            Func<int, int> multyplyFunc = num => num *= 2;
            Func<int, int> subtractFunc = num => num -= 1;
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));


            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    numbers = numbers.Select(addFunc).ToArray();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multyplyFunc).ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtractFunc).ToArray();
                }
                else if (command == "print")
                {
                    print(numbers);
                }

            }
        }
    }
}
