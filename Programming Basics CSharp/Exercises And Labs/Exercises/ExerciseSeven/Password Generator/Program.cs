using System;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int numberLInChar = 97 + l;
            
            for (int i = 1; i <=n; i++)
            {
                
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 97; k <numberLInChar; k++)
                    {
                        for (int g = 97; g < numberLInChar; g++)
                        {
                            
                            for (int t = 1; t <= n; t++)
                            {
                                
                                if (t>i && t > j)
                                {

                                    char symbolK = (char)k;
                                    char symbolG = (char)g;
                                    Console.Write($"{i}{j}{symbolK}{symbolG}{t} ");
                                    

                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
