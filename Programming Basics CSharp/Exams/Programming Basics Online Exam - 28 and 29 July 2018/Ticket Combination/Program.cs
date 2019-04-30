using System;

namespace Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;

            for (int i = 'B'; i <= 'L'; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 'f'; j >= 'a'; j--)
                    {
                        for (int k = 'A'; k <= 'C'; k++)
                        {
                            for (int f = 1; f <= 10; f++)
                            {
                                for (int g = 10; g >= 1; g--)
                                {
                                    bool BigWord = i >= 65 && i <= 76;
                                    if (BigWord)
                                    {
                                        counter++;
                                    }

                                    char y1 = (char)i;
                                    char y2 = (char)j;
                                    char y3 = (char)k;

                                    int x1 = int.Parse(i + "");
                                    int x2 = int.Parse(j + "");
                                    int x3 = int.Parse(k + "");
                                    int x4 = int.Parse(f + "");
                                    int x5 = int.Parse(g + "");


                                    if (counter == number)
                                    {
                                        sum = x1 + x2 + x3 + x4 + x5;
                                        Console.WriteLine($"Ticket combination: {y1}{y2}{y3}{f}{g}");
                                        Console.WriteLine($"Prize: {sum} lv.");
                                        break;
                                    }



                                }
                            }
                        }
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
