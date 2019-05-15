using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int countPoor = 0;
            int countGood = 0;
            int countVeryGood = 0;
            int countExcellent = 0;

            double sum = 0;



            for (int i =1; i<=students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                sum += grade;

                if (grade>=2 && grade<=2.99)
                {
                   
                    countPoor++;
                }
                else if (grade >= 3 && grade <= 3.99)
                {
                    countGood++;
                }
                else if (grade >= 4 && grade <= 4.99)
                {
                    countVeryGood++;
                }
                else if (grade >= 5)
                {
                    countExcellent++;
                }
            }

            double percentPoor = countPoor * 1.0 / students * 100;
            double percentGood = countGood * 1.0 / students * 100;
            double percentVeryGood = countVeryGood * 1.0 / students * 100;
            double percentExcellent = countExcellent * 1.0 / students * 100;

            double avarage = sum / students;

            Console.WriteLine($"Top studenst: {percentExcellent:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentVeryGood:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentGood:F2}%");
            Console.WriteLine($"Fail: {percentPoor:F2}%");
            Console.WriteLine($"Average: {avarage:F2}%");

        }
    }
}
