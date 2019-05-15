using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int weekends = 48;
            double weekendsInSofia = 0;
            


            if (year =="leap")
            {
                if ( h>=0  && p>=0)
                {
                    weekendsInSofia = weekends - h;
                    weekendsInSofia = (3.0 / 4) * weekendsInSofia;
                    double result = (2.0/3) * p;

                    double games = weekendsInSofia + h + result;
                    double finalGames = Math.Floor(games + 0.15 * games);
                    Console.WriteLine(finalGames);
                }
            }
            else if (year == "normal")
            {
                if (h >= 0 && p >= 0)
                {
                    weekendsInSofia = weekends - h;
                    weekendsInSofia = (3.0 / 4) * weekendsInSofia;
                    double result = (2.0 / 3) * p;

                    double games = weekendsInSofia + h + result;
                    double finalGames = Math.Floor(games);
                    Console.WriteLine(finalGames);
                }



            }
            




        }
    }
}
