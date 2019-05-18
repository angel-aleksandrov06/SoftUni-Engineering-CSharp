using System;

namespace _1._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());

            int[] arr = { x1, x2, x3 };
            Array.Sort(arr);
            Array.Reverse(arr);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(arr[i]);
            }

        }
    }
}
