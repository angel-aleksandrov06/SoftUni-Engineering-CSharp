using System;

namespace MoreLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int huderts = int.Parse(Console.ReadLine());
            int tents = int.Parse(Console.ReadLine());
            int ones = int.Parse(Console.ReadLine());

            for (int i = 2; i <= huderts; i+=2)
            {
                for (int j = 2; j <= tents; j++)
                {
                    if (j == 2 || j==3 || j==5 || j==7)
                    {
                        for (int k = 2; k <= ones; k += 2)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
