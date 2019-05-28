using System;

namespace Christmas_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());

            string comand = Console.ReadLine();
            int sumChars = 0;
            int moneyLeft = 0;
            int totalSum = 0;

            while (comand !="Stop")
            {
                for (int i = 0; i < comand.Length; i++)
                {
                    
                    char symbol = comand[comand.Length - 1 - i];
                    sumChars += symbol;
                }
                
                if (sumChars <= budget-totalSum)
                {
                    Console.WriteLine("Item successfully purchased!");
                    
                    totalSum += sumChars;
                }
                else
                {
                    Console.WriteLine("Not enough money!");
                    break;
                }


                comand = Console.ReadLine();


            }
            if (comand == "Stop")
            {
                moneyLeft = budget - totalSum;
                Console.WriteLine($"Money left: {moneyLeft}");
            }
        }
    }
}
