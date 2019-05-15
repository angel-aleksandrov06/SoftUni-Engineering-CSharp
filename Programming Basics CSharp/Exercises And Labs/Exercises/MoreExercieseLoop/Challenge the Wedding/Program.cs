using System;

namespace Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= women; j++)
                {
                    counter++;
                    if (counter > tables)
                    {
                        break;
                    }
                    Console.Write($"({i} <-> {j}) ");

                }
            }
        }
    }
}
