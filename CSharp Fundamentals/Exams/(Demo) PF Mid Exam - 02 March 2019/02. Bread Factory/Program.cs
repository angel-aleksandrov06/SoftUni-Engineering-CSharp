using System;

namespace _02._Bread_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split("|");

            int currentEnergy = 100;
            int coins = 100;


            bool isRushOver = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string[] commandArgs = commands[i].Split("-");

                string @event = commandArgs[0];
                int number = int.Parse(commandArgs[1]);
                
                if(@event == "rest")
                {
                    int newEnergy = number;
                    
                    if(currentEnergy+newEnergy > 100)
                    {
                        int recivedEnergy = 100 - currentEnergy;
                        Console.WriteLine($"You gained {recivedEnergy} energy.");
                        Console.WriteLine($"Current energy: {currentEnergy}.");
                    }
                    else
                    {
                        currentEnergy +=newEnergy;
                        int recivedEnergy = newEnergy;
                        Console.WriteLine($"You gained {recivedEnergy} energy.");
                        Console.WriteLine($"Current energy: {currentEnergy}.");
                    }
                }
                else if(@event == "order")
                {
                    int recivedCoins = number;

                    if (currentEnergy >= 30)
                    {
                        Console.WriteLine($"You earned {recivedCoins} coins.");
                        currentEnergy -= 30;
                        coins += recivedCoins;
                    }
                    else
                    {
                        Console.WriteLine($"You had to rest!");
                        currentEnergy += 50;
                    }
                }
                else
                {
                    if (coins > 0)
                    {
                        int price = number;
                        string ingredient = @event;

                        if (coins > price)
                        {
                            Console.WriteLine($"You bought {ingredient}.");
                            coins -= price;
                        }
                        else
                        {
                            Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                            isRushOver = true;
                            break;
                        }
                    }
                    
                }
            }

            if(isRushOver == false)
            {
                Console.WriteLine($"Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {currentEnergy}");
            }
            
        }
    }
}
