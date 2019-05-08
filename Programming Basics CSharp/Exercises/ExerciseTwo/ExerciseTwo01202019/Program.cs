using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo01202019
{
    class Program
    {
        static void Main(string[] args)
        {
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            int totalTime = time1 + time2 + time3;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if (seconds<=9)
            {
                Console.WriteLine(minutes + ":0" + seconds);
            }
            else
            {
                Console.WriteLine(minutes + ":" + seconds);
            }


        }
    }
}
