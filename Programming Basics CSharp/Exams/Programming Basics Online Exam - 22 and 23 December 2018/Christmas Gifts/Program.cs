using System;

namespace Christmas_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int counterKids = 0;
            int counterPeoples = 0;
            int moneyForToys = 0;
            int moneyForSweaters = 0;

            while (comand!="Christmas")
            {
                int years = int.Parse(comand);

                if(years<=16)
                {
                    counterKids++;
                    moneyForToys += 5;
                }
                else
                {
                    counterPeoples++;
                    moneyForSweaters += 15;
                }

                comand = Console.ReadLine();
            }
            Console.WriteLine($"Number of adults: {counterPeoples}");
            Console.WriteLine($"Number of kids: {counterKids}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
