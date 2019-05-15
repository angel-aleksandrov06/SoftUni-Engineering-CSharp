using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGradeMax = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();

            int counter = 0;
            int sumGrade = 0;
            int badGrade = 0;
            string lastTask = "";

            while(task !="Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                sumGrade += grade;
                if (grade<=4)
                {
                    badGrade++;
                }

                if (badGrade == badGradeMax)
                {
                    Console.WriteLine($"You need a break, {badGrade} poor grades.");
                    break;
                }
                lastTask = task;
                task = Console.ReadLine();
                counter++;

            }

            if (task == "Enough")
            {
                double averrage = sumGrade * 1.0 / counter;

                Console.WriteLine($"Average score: {averrage:F2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastTask}");
            }


        }
    }
}
