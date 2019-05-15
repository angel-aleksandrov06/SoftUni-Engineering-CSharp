using System;

namespace Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            string st1 = Console.ReadLine();
            string st2 = Console.ReadLine();
            string st3 = Console.ReadLine();
            int counter = 0;

            char s1 = st1[0];
            char s2 = st2[0];
            char s3 = st3[0];

            for (int i = s1; i <= s2; i++)
            {
                for (int j = s1; j <= s2; j++)
                {
                    for (int k = s1; k <= s2; k++)
                    {
                        if (i==s3 || j==s3 || k==s3)
                        {
                            continue;
                        }
                        else
                        {
                            char symbol1 = (char)i;
                            char symbol2 = (char)j;
                            char symbol3 = (char)k;
                            counter++;
                            Console.Write($"{symbol1}{symbol2}{symbol3} ");
                        }
                    }
                }
            }
            Console.Write(counter);
        }
    }
}
