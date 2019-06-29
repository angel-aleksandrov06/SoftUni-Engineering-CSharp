using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNoisyKids = Console.ReadLine().Split("&").ToList();

            string command = Console.ReadLine();

            while (command!= "Finished!")
            {
                string[] commandArgs = command.Split(" ");

                string type = commandArgs[0];
                string kidName = commandArgs[1];
                

                bool isKindExist = inputNoisyKids.Contains(kidName);

                if(type == "Bad" && isKindExist==false)
                {
                    inputNoisyKids.Insert(0, kidName);
                }

                else if (type == "Good" && isKindExist)
                {
                    inputNoisyKids.Remove(kidName);
                }

                else if(type == "Rename" && isKindExist)
                {
                    string newName = commandArgs[2];
                    int index = inputNoisyKids.IndexOf(kidName);
                    inputNoisyKids.Remove(kidName);
                    inputNoisyKids.Insert(index, newName);
                }

                else if(type=="Rearrange" && isKindExist)
                {
                    inputNoisyKids.Remove(kidName);
                    inputNoisyKids.Add(kidName);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",inputNoisyKids));
        }
    }
}
