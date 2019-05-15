using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grades = 1;
            double sum = 0;
            int badGrades = 0;

            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum += grade;
                    grades++;
                }
                else
                {
                    badGrades++;
                    if (badGrades >= 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grades} grade");
                        break;
                    }
                }



            }
            if (badGrades < 2)
            { double avarage = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {avarage:F2}");
            }



        }
    }
}
