using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int freeCake = width * length;
            int onePieceOfCake = 1;


            int totalPieceOfCake = 0;
            int cakeDiff = 0 ;
           

            string command = Console.ReadLine();
            while (true)
            {
                int pieceSpace = int.Parse(command);
                totalPieceOfCake += pieceSpace;

                cakeDiff = Math.Abs(totalPieceOfCake - freeCake);

                    if (totalPieceOfCake>=freeCake)
                    {
                        Console.WriteLine($"No more cake left! You need {cakeDiff} pieces more.");
                        break;
                    }
                command = Console.ReadLine();
                    if (command =="STOP" && freeCake>0)
                    {
                    Console.WriteLine($"{cakeDiff} pieces are left.");
                    break;
                    }

            }
            
        }
    }
}
