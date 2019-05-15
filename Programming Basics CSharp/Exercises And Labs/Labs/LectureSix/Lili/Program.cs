using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lili
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int moneyYears = 0;
            int toyYears = 0;
            double birthdayMoney = 0;
            int evenBirthdaysCount = 0;
            int toysCount = 0;

            for (int birthdayNumber = 1; birthdayNumber <= age; birthdayNumber++ )
            {
                if (birthdayNumber % 2==0)
                {
                    evenBirthdaysCount++;
                    birthdayMoney += evenBirthdaysCount * 10;
                    
                }
                else
                {
                    toysCount++;
                }
            }


            int moneyFormSoldToys = toysCount * toyPrice;

            int moneyClaimedFromBrother = evenBirthdaysCount * 1;
            double resultingMoney = birthdayMoney + moneyFormSoldToys - moneyClaimedFromBrother;

            if (resultingMoney >= washingMachinePrice)
            {
                double leftOverMoney = resultingMoney - washingMachinePrice;
                Console.WriteLine($"Yes! {leftOverMoney:F2}");
            } 
            else
            {
                double unsufficientMoney = washingMachinePrice-resultingMoney;
                Console.WriteLine($"No! {unsufficientMoney:F2}");
            }

           
            
        }
    }
}
