using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int weekends = 48;
            int weekendsInSofia = 0;


            if (year == "leap")
            {
                if (h > 0 && p > 0)
                {
                    weekendsInSofia = weekends - h;
                    double result = (2 / 3) * p;

                    double games = weekendsInSofia + h + result;
                    games = Math.Floor(games + 0.15 * games);

                }



            }
        }
    }
}
