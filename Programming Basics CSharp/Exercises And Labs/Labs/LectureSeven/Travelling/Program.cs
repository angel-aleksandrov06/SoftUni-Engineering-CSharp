using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string Destitation = Console.ReadLine();
            

            while (Destitation != "End")
            {
                
                double minBudget = double.Parse(Console.ReadLine());
                double savedMoney = 0;

                while (savedMoney<minBudget)
                {
                    double incomeMoney = double.Parse(Console.ReadLine());
                    savedMoney += incomeMoney;

                }
                if (savedMoney>=minBudget)
                {
                    Console.WriteLine($"Going to {Destitation}!");
                }
                
                Destitation = Console.ReadLine();
            }
            
        }
    }
}
