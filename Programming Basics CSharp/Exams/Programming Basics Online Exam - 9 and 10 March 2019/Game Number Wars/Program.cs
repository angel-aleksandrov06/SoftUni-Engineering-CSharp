using System;

namespace Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firtsPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();

            string comandOne = Console.ReadLine();
            string comandTwo = Console.ReadLine();

            int countPointOne = 0;
            int countPointTwo = 0;
            string insideComand = "";

            int firstPlayCard = 0;
            int secondPlayCard = 0;

            while (comandOne!= "End of game" && comandTwo!= "End of game")
            {
                firstPlayCard = int.Parse(comandOne);
                secondPlayCard = int.Parse(comandTwo);

                if (firstPlayCard > secondPlayCard)
                {
                    countPointOne+= firstPlayCard - secondPlayCard;

                }
                else if(firstPlayCard<secondPlayCard)
                {
                    countPointTwo+= secondPlayCard - firstPlayCard;
                }
                else if (firstPlayCard == secondPlayCard)
                {
                    insideComand = "Number wars";
                    firstPlayCard = int.Parse(Console.ReadLine());
                    secondPlayCard = int.Parse(Console.ReadLine());
                    break;
                }

                comandOne = Console.ReadLine();
                comandTwo = Console.ReadLine();
                
            }
            if(insideComand== "Number wars")
            {
                if (firstPlayCard > secondPlayCard)
                {
                    Console.WriteLine("Number wars!");
                    Console.WriteLine($"{firtsPlayer} is winner with {countPointOne} points");
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    Console.WriteLine($"{secondPlayer} is winner with {countPointTwo} points");
                }
            }
            else
            {
                Console.WriteLine($"{firtsPlayer} has {countPointOne} points");
                Console.WriteLine($"{secondPlayer} has {countPointTwo} points");
            }
        }
    }
}
