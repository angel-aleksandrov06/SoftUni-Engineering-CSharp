using System;

namespace exerciseSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int firstRowFirstCol = a; firstRowFirstCol <= b; firstRowFirstCol++)
            {
                for (int firstRowSecondCol = a; firstRowSecondCol <= b; firstRowSecondCol++)
                {
                    for (int secondRowFirstCol = c; secondRowFirstCol <= d; secondRowFirstCol++)
                    {
                        for (int secondRowSecondCol = c; secondRowSecondCol <= d; secondRowSecondCol++)
                        {

                            bool equalSum = firstRowFirstCol + secondRowSecondCol == firstRowSecondCol + secondRowFirstCol;
                            bool fRowfColEqualToFRowsecondCol = firstRowFirstCol != firstRowSecondCol;
                            bool sRowfColEqualTosRowsecondCol = secondRowFirstCol != secondRowSecondCol;

                            if (equalSum && fRowfColEqualToFRowsecondCol && sRowfColEqualTosRowsecondCol)
                            {
                                Console.WriteLine(""+firstRowFirstCol+firstRowSecondCol);
                                Console.WriteLine(""+secondRowFirstCol+secondRowSecondCol);
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

        }
    }
}
