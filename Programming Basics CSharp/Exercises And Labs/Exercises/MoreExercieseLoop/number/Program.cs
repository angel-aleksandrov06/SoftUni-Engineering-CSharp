using System;

namespace number
{
    class Program
    {
        static void Main(string[] args)
        {
            int startN = int.Parse(Console.ReadLine());
            int stopN = int.Parse(Console.ReadLine());

            for (int i = startN; i <= stopN; i++)
            {
                for (int j = startN; j <= stopN; j++)
                {
                    for (int k = startN; k <= stopN; k++)
                    {
                        for (int g = startN; g <= stopN; g++)
                        {

                            bool first = i % 2 == 0 && g % 2 != 0;
                            bool second = i % 2 != 0 && g % 2 == 0;
                            bool biger = i > g;
                            bool sum = (j + k) % 2 == 0;
                            if(first || second)
                            {
                                if (i > g)
                                {
                                    if (sum)
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
}
