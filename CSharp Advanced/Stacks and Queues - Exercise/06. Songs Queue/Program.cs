using System;
using System.Collections.Generic;
using System.Linq;


namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (songs.Count > 0)
            {
                string line = Console.ReadLine();
                var commandParts = line.Split();

                string command = commandParts[0];

                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        string songName = line.Substring(4);
                        bool contains = songs.Contains(songName);

                        if (contains)
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(songName);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
