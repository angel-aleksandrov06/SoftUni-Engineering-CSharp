using System;

namespace rooms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersFloors = int.Parse(Console.ReadLine());
            int numbersRooms = int.Parse(Console.ReadLine());

            for(int i=numbersFloors ; i>=1; i--)
            {
                

                for(int j =0; j<numbersRooms; j++)
                {
                    if (i == numbersFloors)
                    {
                        Console.Write($"L{i}{j} ");
                    }

                    else if (i % 2 == 0)
                    {

                        Console.Write($"O{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{j} ");
                    }
                }

                Console.WriteLine();

            }
        }
    }
}
