using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double incomeMoney = double.Parse(Console.ReadLine());
            double advancement = double.Parse(Console.ReadLine());
            double minIncomeSalary = double.Parse(Console.ReadLine());
            double socialScholarShip = 0;
            double gradeScholarShip = 0;

            if (incomeMoney > minIncomeSalary)
            {
                if (advancement < 5.50)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if (advancement >= 5.50)
                {
                    gradeScholarShip = advancement * 25;
                    Console.WriteLine($"You get a scholarship for excellent results {gradeScholarShip} BGN");
                }
            }
            else if (incomeMoney<=minIncomeSalary)
            {
                if (advancement < 5.50)
                {
                    socialScholarShip = 0.35 * minIncomeSalary;
                    Console.WriteLine($"You get a Social scholarship {socialScholarShip} BGN");
                }
                else if (advancement >= 5.50)
                {
                    gradeScholarShip = Math.Floor(advancement * 25);    
                    socialScholarShip = Math.Floor(0.35 * minIncomeSalary);
                    if (gradeScholarShip>=socialScholarShip)
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {gradeScholarShip} BGN");
                    }
                    else if (socialScholarShip>gradeScholarShip)
                    {
                        Console.WriteLine($"You get a Social scholarship {socialScholarShip} BGN");
                    }
                }
            }

            
          

        }
    }
}
