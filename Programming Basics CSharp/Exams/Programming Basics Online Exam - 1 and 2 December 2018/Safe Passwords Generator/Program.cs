using System;

namespace Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int counter = 0;
            int i = 35;
            int j = 64;

            for (int k = 1; k <= a; k++)
            {
                for (int g = 1; g <= b; g++)
                {
                    if (i > 55)
                    {
                        i = 35;
                    }
                    if (j > 96)
                    {
                        j = 64;
                    }
                    char symbol1 = (char)i;
                    char symbol2 = (char)j;
                    counter++;


                    if (counter <= max)
                    {

                        Console.Write($"{symbol1}{symbol2}{k}{g}{symbol2}{symbol1}|");
                    }
                    else
                    {
                        break;
                    }
                    i++;
                    j++;


                }
            }


        }
    }
}
