using System;
using System.Numerics;

namespace Mid_Exam___30_June_2019_Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double lenthOneStep = double.Parse(Console.ReadLine());
            int distanceNeedForTravel = int.Parse(Console.ReadLine());

            double shortestStep = lenthOneStep - (lenthOneStep * 0.30);
            double allShortestSteps = 0;
            double allNormalSteps = 0;

            double madeDistance = 0;

            for (int i = 1; i <= stepsMade; i++)
            {
                if(i%5 == 0)
                {
                    allShortestSteps += shortestStep;
                    continue;
                }
               
                allNormalSteps += lenthOneStep;
                
            }

            madeDistance = allNormalSteps + allShortestSteps;

            double percentMadeDistance = madeDistance / distanceNeedForTravel;

            Console.WriteLine($"You travelled { percentMadeDistance:f2}% of the distance!");
        }
    }
}
