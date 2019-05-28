using System;

namespace Own_Bussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int widthRoom = int.Parse(Console.ReadLine());
            int lenghtRoom = int.Parse(Console.ReadLine());
            int heightRoom = int.Parse(Console.ReadLine());

            int roomArea = widthRoom * lenghtRoom * heightRoom;
            int spaceComputers = 0;

            string comand = Console.ReadLine();

            while (comand!="Done")
            {
                int Computers = int.Parse(comand);

                spaceComputers += Computers;
                if (spaceComputers > roomArea) 
                {
                    int needspace = spaceComputers - roomArea;
                    Console.WriteLine($"No more free space! You need {needspace} Cubic meters more.");
                    break;
                }
                comand = Console.ReadLine();
            }
            if (comand == "Done")
            {
                int leftSpace = roomArea - spaceComputers;
                Console.WriteLine($"{leftSpace} Cubic meters left.");
            }
        }
    }
}
