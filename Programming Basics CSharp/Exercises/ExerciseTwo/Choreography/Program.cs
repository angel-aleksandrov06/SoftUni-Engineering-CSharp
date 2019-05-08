using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double totalStepPerDay = Math.Ceiling(((steps*1.0 / days) / steps) *100);
            double stepPerDancers = totalStepPerDay / dancers;
            if (totalStepPerDay<= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepPerDancers:F2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {stepPerDancers:F2}% steps to be learned per day.");
            }
        }
    }
}
