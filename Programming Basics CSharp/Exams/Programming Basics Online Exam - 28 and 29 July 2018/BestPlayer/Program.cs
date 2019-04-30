using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int goals = int.Parse(Console.ReadLine());
            int maxGoals = int.MinValue;
            string goalMaster = "";

            while (name !="END")
            {
               if(goals>maxGoals)
               {
                    goalMaster = name;
                    maxGoals = goals;
               }
               
                if(goals>=10)
                {
                    break;
                }
                name = Console.ReadLine();
                if (name != "END")
                {
                    goals = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"{goalMaster} is the best player!");
            if (goals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
            
        }
    }
}
