using System;
using System.Linq;
using System.Collections.Generic;


namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var dictSentRecived = new Dictionary<string, int[]>();

            while (input != "Statistics")
            {
                var splitedInput = input.Split("=");
                var command = splitedInput[0];

                if (command == "Add")
                {
                    var username = splitedInput[1];
                    var sent = int.Parse(splitedInput[2].ToString());
                    var recived = int.Parse(splitedInput[3].ToString());

                    if (!dictSentRecived.ContainsKey(username))
                    {
                        dictSentRecived[username] = new int[2];

                        dictSentRecived[username][0] = sent;
                        dictSentRecived[username][1] = recived;
                    }
                }
                else if (command == "Message")
                {
                    var sender = splitedInput[1];
                    var reciver = splitedInput[2];

                    if (dictSentRecived.ContainsKey(reciver) && dictSentRecived.ContainsKey(sender))
                    {
                        dictSentRecived[sender][0] += 1;
                        dictSentRecived[reciver][1] += 1;

                        if (dictSentRecived[sender].Sum() >=capacity)
                        {
                            dictSentRecived.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (dictSentRecived[reciver].Sum() >= capacity)
                        {
                            dictSentRecived.Remove(reciver);
                            Console.WriteLine($"{reciver} reached the capacity!");
                        }
                    }
                }
                else if (command == "Empty")
                {
                    var username = splitedInput[1];

                    if (username == "All")
                    {
                        dictSentRecived = new Dictionary<string, int[]>();
                    }
                    else
                    {
                        if (dictSentRecived.ContainsKey(username))
                        {
                            dictSentRecived.Remove(username);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {dictSentRecived.Count}");

            foreach (var pers in dictSentRecived.OrderByDescending(x=>x.Value[1]).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{pers.Key} - {pers.Value.Sum()}");

            }
        }
    }
}
