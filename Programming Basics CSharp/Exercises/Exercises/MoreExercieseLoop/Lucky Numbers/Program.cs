using System;

namespace Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <=9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int g = 1; g <= 9; g++)
                        {
                            int sum = i + j;
                            int sum2 = k + g;
                            
                            if (sum==sum2)
                            {
                                if(N % sum == 0)
                                {
                                    Console.Write($"{i}{j}{k}{g} ");
                                }
                                
                            }

                        }
                    }
                }
            }
        }
    }
}
