using System;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|");

            int health = 100;
            int coins = 0;


            bool isYouDead = false;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] commandArgs = rooms[i].Split(" ");

                string @event = commandArgs[0];
                int number = int.Parse(commandArgs[1]);

                if (@event == "potion")
                {
                    int newEnergy = number;

                    if (health + newEnergy > 100)
                    {
                        int recivedHealth = 100 - health;
                        health += recivedHealth;
                        Console.WriteLine($"You healed for {recivedHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        health += newEnergy;
                        int recivedEnergy = newEnergy;
                        Console.WriteLine($"You healed for {recivedEnergy} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (@event == "chest")
                {
                    int recivedCoins = number;
                    coins += recivedCoins;

                    Console.WriteLine($"You found {recivedCoins} coins.");
                    
                }
                else
                {
                    int powerOfMonster = number;
                    string monster = @event;

                    health -= powerOfMonster;

                    if (health > 0)
                    {
                         Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        int room = i +1;
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {room}");

                        isYouDead = true;
                        break;
                    }

                }
            }

            if (isYouDead == false)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }

        }
    }
}