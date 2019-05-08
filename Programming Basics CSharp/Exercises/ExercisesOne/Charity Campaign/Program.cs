using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {

            double days = double.Parse(Console.ReadLine());
            double cookers = double.Parse(Console.ReadLine());
            double cakesCount = double.Parse(Console.ReadLine());
            double waffelsCount = double.Parse(Console.ReadLine());
            double pancakesCount = double.Parse(Console.ReadLine());

            double cakesSum = cakesCount * 45;
            double waffelSum = waffelsCount * 5.80;
            double pancakesSum = pancakesCount * 3.20;

            double sumOneDay = (cakesSum + waffelSum + pancakesSum) * cookers;
            double sumCampany = sumOneDay * days;
            double sumFinaly = sumCampany -  (0.125) * sumCampany ;
            
            Console.WriteLine($"{sumFinaly:F2}");


        }
    }
}
