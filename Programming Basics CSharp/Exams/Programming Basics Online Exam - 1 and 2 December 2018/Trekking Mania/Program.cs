using System;

namespace Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGroups = int.Parse(Console.ReadLine());
            int allPeople = 0;

            int musalaCount = 0;
            int monblanCount = 0;
            int kilimandjaroCount = 0;
            int k2Count = 0;
            int everestCount = 0;

            for (int i = 1; i <= countGroups; i++)
            {
                int countPeopleInGroups = int.Parse(Console.ReadLine());

                bool musala = countPeopleInGroups <= 5;
                bool monblan = countPeopleInGroups > 5 && countPeopleInGroups <= 12;
                bool kilimadjaro = countPeopleInGroups >12 && countPeopleInGroups<=25;
                bool K2 = countPeopleInGroups >25 && countPeopleInGroups<=40;
                bool Everest = countPeopleInGroups >40;

                allPeople += countPeopleInGroups;

                if (musala)
                {
                    musalaCount+=countPeopleInGroups;
                }
                else if (monblan)
                {
                    monblanCount += countPeopleInGroups;
                }
                else if (kilimadjaro)
                {
                    kilimandjaroCount += countPeopleInGroups;
                }
                else if (K2)
                {
                    k2Count += countPeopleInGroups;
                }else if (Everest)
                {
                    everestCount += countPeopleInGroups;
                }
                
            }
            double musalaCountPercent = musalaCount * 1.0 / allPeople * 100;
            double monblanCountPercent = monblanCount*1.0/allPeople*100;
            double kilimandjaroCountPercent = kilimandjaroCount*1.0/allPeople*100;
            double k2CountPercent = k2Count*1.0/allPeople*100;
            double everestCountPercent = everestCount*1.0/allPeople*100;

            Console.WriteLine($"{musalaCountPercent:F2}%");
            Console.WriteLine($"{monblanCountPercent:F2}%");
            Console.WriteLine($"{kilimandjaroCountPercent:F2}%");
            Console.WriteLine($"{k2CountPercent:F2}%");
            Console.WriteLine($"{everestCountPercent:F2}%");

        }
    }
}
