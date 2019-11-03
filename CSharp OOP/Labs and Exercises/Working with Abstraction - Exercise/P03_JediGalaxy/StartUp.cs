using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Galaxy galaxy = new Galaxy(dimestions);

            galaxy.Create();

            string command = Console.ReadLine();
            long sumOfPoints = 0;

            while (command != "Let the Force be with you")
            {
                int[] playerPosition = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Player player = new Player(playerPosition);
                int[] evilPositon = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Evil evil = new Evil(evilPositon);

                galaxy.MoveEvil(evil);
                sumOfPoints = galaxy.MovePlayer(player, sumOfPoints);

                command = Console.ReadLine();
            }

            Console.WriteLine(sumOfPoints);
        }
    }
}
