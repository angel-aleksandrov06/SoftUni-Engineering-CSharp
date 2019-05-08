using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            // read grade from console 
            double grade = double.Parse(Console.ReadLine());
            double lowestExcellentGradeValue = 5.5;
            bool isGradeExcellent = grade >= lowestExcellentGradeValue;
            // make the check 
            if (isGradeExcellent)
            {
                // true
                Console.WriteLine("Excellent!");
            }
            else
            {
            }
            // true or false

            // write to console



        }
    }
}
