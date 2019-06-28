using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cooking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<int> breadBatch = new List<int>();

            int maxQuality = int.MinValue;
            double averageMaxQuality = double.MinValue;
            int shortestList = int.MaxValue;

            while (command != "Bake It!")
            {
                List<int> batchesOfBread = command.Split("#").Select(x => int.Parse(x)).ToList();
                int currentTotalQuality = batchesOfBread.Sum();
                double currentaverageQuality = currentTotalQuality*1.0 / batchesOfBread.Count;
                int currentLength = batchesOfBread.Count;

                if (currentTotalQuality > maxQuality)
                {
                    maxQuality = currentTotalQuality;
                    averageMaxQuality = currentaverageQuality;
                    shortestList = currentLength;
                    breadBatch = batchesOfBread;
                }
                else if(currentTotalQuality == maxQuality)
                {
                    if (currentaverageQuality > averageMaxQuality)
                    {
                        maxQuality = currentTotalQuality;
                        averageMaxQuality = currentaverageQuality;
                        shortestList = currentLength;
                        breadBatch = batchesOfBread;
                    }
                    else if (currentaverageQuality == averageMaxQuality)
                    {
                        if (currentLength < shortestList)
                        {
                            maxQuality = currentTotalQuality;
                            averageMaxQuality = currentaverageQuality;
                            shortestList = currentLength;
                            breadBatch = batchesOfBread;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {maxQuality}");
            Console.WriteLine(string.Join(" ",breadBatch));
        }
    }
}
