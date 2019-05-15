using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double needMoneyVacation = double.Parse(Console.ReadLine());
            double moneyOnHand = double.Parse(Console.ReadLine());

            int spendCounter = 0;
            int daysCounter = 0;

            while (moneyOnHand<needMoneyVacation && spendCounter<5)
            {
                string action = Console.ReadLine();
                double spendOrSaveSum = double.Parse(Console.ReadLine());
                daysCounter++;
                if (action=="save")
                {
                    moneyOnHand += spendOrSaveSum;
                    spendCounter = 0;
                }
                if (action == "spend")
                {
                    moneyOnHand -= spendOrSaveSum;
                    spendCounter++;

                }
                if (moneyOnHand<0)
                {
                    moneyOnHand = 0;
                }
                
            }
            if (spendCounter==5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysCounter}");
            }
            if (moneyOnHand >= needMoneyVacation)
            {
                Console.WriteLine($" You saved the money for {daysCounter} days.");
            }





        }
    }
}
