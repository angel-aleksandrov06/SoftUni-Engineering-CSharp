using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();

            while (command!= "Retire!")
            {
                string[] inputCommands = command.Split(" - ");

                string type = inputCommands[0];
                string quest = inputCommands[1];

                bool isQuestExist = input.Contains(quest);

                if (type == "Start" && isQuestExist==false)
                {
                     input.Add(quest);
                }

                else if(type == "Complete" && isQuestExist == true)
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input.Contains(quest))
                        {
                            input.Remove(quest);
                            i--;
                        }
                    }
                }

                else if(type == "Side Quest")
                {
                    string[] sideQuestArray = quest.Split(":");
                    string newQuest = sideQuestArray[0];
                    string sideQuest = sideQuestArray[1];
                    bool isSideQuestExist = input.Contains(sideQuest);

                    if (input.Contains(newQuest) && isSideQuestExist == false)
                    {
                        int index = input.IndexOf(newQuest);
                        input.Insert(index + 1, sideQuest);
                    }
                }

                else if(type == "Renew" && isQuestExist==true)
                {
                    input.Remove(quest);
                    input.Add(quest);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
