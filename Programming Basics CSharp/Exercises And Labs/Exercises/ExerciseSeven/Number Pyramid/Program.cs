using System;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int current = 1;
            bool isBigger = false;
            for (int rows = 0; rows <= n; rows++)
            {
                for (int colms = 0; colms <= rows; colms++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;

                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
