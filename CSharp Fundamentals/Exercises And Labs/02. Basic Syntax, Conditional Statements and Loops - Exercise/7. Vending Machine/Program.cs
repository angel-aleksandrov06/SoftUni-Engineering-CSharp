using System;

namespace _7._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string insertComand = Console.ReadLine();
            double moneyInMashine = 0;

            while (insertComand!="Start")
            {
                double incomeMoney = double.Parse(insertComand);
                if(incomeMoney==0.1 || incomeMoney == 0.2 || incomeMoney == 0.5 || incomeMoney == 1 || incomeMoney == 2)
                {
                    moneyInMashine += incomeMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {incomeMoney}");
                }
                insertComand = Console.ReadLine();
            }
            insertComand = Console.ReadLine();
            while (insertComand!="End")
            {

                if (insertComand == "Nuts")
                {
                    
                    if (moneyInMashine>=2.0)
                    {
                        Console.WriteLine($"Purchased nuts");
                        moneyInMashine -= 2.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if(insertComand == "Water")
                {
                    if (moneyInMashine >= 0.7)
                    {
                        Console.WriteLine($"Purchased water");
                        moneyInMashine -= 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if(insertComand == "Crisps")
                {
                    if (moneyInMashine >= 1.5)
                    {
                        Console.WriteLine($"Purchased crisps");
                        moneyInMashine -= 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if(insertComand == "Soda")
                {
                    if (moneyInMashine >= 0.8)
                    {
                        Console.WriteLine($"Purchased soda");
                        moneyInMashine -= 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if(insertComand == "Coke")
                {
                    if (moneyInMashine >= 1.0)
                    {
                        Console.WriteLine($"Purchased coke");
                        moneyInMashine -= 1.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                
                insertComand = Console.ReadLine();
            }
            Console.WriteLine($"Change: {moneyInMashine:F2}");
        }
    }
}
