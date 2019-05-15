using System;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int quota = int.Parse(Console.ReadLine());
            
            double priceOfCurrentFish = 0;
            
            double moneyForThithFish = 0;
            double profitmoneyFromFish = 0;
            double earnOrLostMoney = 0;
            int counterFish = 0;
            for (int i = 1; i <= quota; i++)
            {
                double totalPriceForFish = 0;
                int sumSymbols = 0;
                string nameOfFish = Console.ReadLine();

                if(nameOfFish == "Stop")
                {
                    break;
                }
                if (i == quota)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                }
               double kgOfFish = double.Parse(Console.ReadLine());

                for (int j = 0; j < nameOfFish.Length; j++)
                {
                    
                    int symbol = nameOfFish[nameOfFish.Length - 1 - j];
                    sumSymbols += symbol;
                    priceOfCurrentFish = sumSymbols*1.0/ kgOfFish;
                   
                        
                    
                   
                    
                    
                }
                totalPriceForFish += priceOfCurrentFish;
                if (i % 3 == 0)
                {
                    profitmoneyFromFish += totalPriceForFish;
                    
                }
                else
                {
                    moneyForThithFish += totalPriceForFish;
                }
                counterFish++;
                
            }
            earnOrLostMoney = Math.Abs(profitmoneyFromFish-moneyForThithFish);
            if(moneyForThithFish>profitmoneyFromFish)
            {
                Console.WriteLine($"Lyubo lost {earnOrLostMoney:F2} leva today.");
            }
            else
            {
                Console.WriteLine($"Lyubo's profit from {counterFish} fishes is {earnOrLostMoney:F2} leva.");
            }
        }
    }
}
