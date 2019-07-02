using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputCommands = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command!=null)
            {

                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = commands[0];

                if(type == "Add")
                {
                    string contact = commands[1];
                    int index = int.Parse(commands[2]);

                    if (inputCommands.Contains(contact))
                    {
                        if (index >= 0 && index < inputCommands.Count)
                        {
                            inputCommands.Insert(index, contact);
                        }
                    }
                    else
                    {
                        inputCommands.Add(contact);
                    }
                }

                else if(type == "Remove")
                {
                    int index = int.Parse(commands[1]);

                    if (index >= 0 && index < inputCommands.Count)
                    {
                        inputCommands.RemoveAt(index);
                    }
                }

                else if(type == "Export")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);
                    count = Math.Abs(count);

                    bool isCountExist = startIndex + count < inputCommands.Count;

                    
                    if(startIndex>=0 && startIndex < inputCommands.Count)
                    {
                        if(isCountExist == false)
                        {
                            for (int i = startIndex; i < inputCommands.Count; i++)
                            {
                                Console.Write(inputCommands[i] + " ");
                            }
                        }
                        else
                        {
                            for (int i = startIndex; i < startIndex+count; i++)
                            {
                                  Console.Write(inputCommands[i] + " ");
                            }
                        }

                        Console.WriteLine();
                    }
                }
                else if (type == "Print")
                {
                    string typeOfPrinting = commands[1];

                    if(typeOfPrinting == "Normal")
                    {
                        Console.Write($"Contacts: ");
                        Console.WriteLine(string.Join(" ",inputCommands));
                        Console.WriteLine();

                    }
                    else if(typeOfPrinting == "Reversed")
                    {
                        Console.Write($"Contacts: ");
                        inputCommands.Reverse();
                        Console.WriteLine(string.Join(" ",inputCommands));
                        
                    }
                    break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
