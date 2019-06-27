using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Pictures = Console.ReadLine().Split(" ").ToList();
            int lenghtOfList = Pictures.Count;
            List<string> comand = Console.ReadLine().Split(" ").ToList();

            while (comand[0] != "END")
            {
                if (comand[0] == "Change")
                {

                    for (int i = 0; i < Pictures.Count; i++)
                    {
                        if (Pictures[i].Equals(comand[1]))
                        {
                            Pictures[i] = comand[2];
                            break;
                        }

                    }
                }

                else if (comand[0] == "Hide")
                {
                    for (int i = 0; i < Pictures.Count; i++)
                    {
                        if (Pictures[i].Contains(comand[1]))
                        {
                            Pictures.Remove(comand[1]);
                        }

                    }
                }

                else if (comand[0] == "Switch")
                {
                    for (int i = 0; i < Pictures.Count; i++)
                    {
                        if (Pictures[i].Contains(comand[1]))
                        {

                            for (int j = 0; j < Pictures.Count; j++)
                            {
                                if (Pictures[j].Contains(comand[2]))
                                {
                                    Pictures[i] = comand[2];
                                    Pictures[j] = comand[1];
                                    i = Pictures.Count;
                                    break;
                                }
                            }
                        }

                    }
                }

                else if (comand[0] == "Insert")
                {
                    int place = (int.Parse(comand[1]));

                    if (place >= -1 && place < Pictures.Count)
                    {
                        if (place.Equals(Pictures.Count - 1))
                        {
                            Pictures.Add(comand[2]);
                        }
                        else
                        {
                            Pictures.Insert(place + 1, comand[2]);
                        }
                    }
                }

                else if (comand[0] == "Reverse")
                {
                    Pictures.Reverse();
                }

                comand = Console.ReadLine().Split(" ").ToList();
            }

            Console.WriteLine(string.Join(" ", Pictures));
        }
    }
}
