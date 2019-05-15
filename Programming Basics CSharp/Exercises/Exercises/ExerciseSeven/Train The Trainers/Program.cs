using System;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countJury = int.Parse(Console.ReadLine());

            string presentation = Console.ReadLine();
            double sumAllGrades = 0;
            int counter = 0;
            while (presentation != "Finish")
            {

                double sum = 0;
                for (int i = 1; i <= countJury; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sum += grade;

                    sumAllGrades += grade;
                    counter++;
                }
                double avarage = sum / countJury;
                Console.WriteLine($"{presentation} - {avarage:F2}.");

                presentation = Console.ReadLine();
            }
            double avarageAllGrades = sumAllGrades / counter;
            if (presentation == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {avarageAllGrades:F2}.");
            }
        }
    }
}
