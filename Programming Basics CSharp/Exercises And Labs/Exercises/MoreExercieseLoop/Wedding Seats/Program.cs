using System;

namespace Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastSector = char.Parse(Console.ReadLine());
            int countRows = int.Parse(Console.ReadLine());
            int countSeatsOdd = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 'A'; i <=lastSector; i++)
            {
                for (int j = 1; j <= countRows; j++)
                {
                    char bigSymbol = (char)i;
                    if (j % 2 == 0)
                    {
                        for (int k = 97; k < 99 + countSeatsOdd; k++)
                        {
                            char smallSymbol2 = (char)k;
                            counter++;
                            Console.WriteLine($"{bigSymbol}{j}{smallSymbol2}");
                        }
                    }
                    else
                    {
                        for (int k = 97; k < 97+countSeatsOdd; k++)
                        {
                            char smallSymbol = (char)k;
                            counter++;
                            Console.WriteLine($"{bigSymbol}{j}{smallSymbol}");
                        }
                    }
                    
                }
                countRows++;
            }
            Console.WriteLine(counter);

        }
    }
}
