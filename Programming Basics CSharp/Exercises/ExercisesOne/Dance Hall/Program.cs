using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenghtHall = double.Parse(Console.ReadLine());
            double widthHall = double.Parse(Console.ReadLine());
            double sideWardrobe = double.Parse(Console.ReadLine());

            double areaHall = (lenghtHall * 100) * (widthHall * 100);
            double areaWardrobe = (sideWardrobe * 100) * (sideWardrobe * 100);
            double areaBench = areaHall / 10;
            double freeSpace = areaHall - areaWardrobe - areaBench;
            double dancers = freeSpace / 7040;

            Console.WriteLine(Math.Floor(dancers));





        }
    }
}
