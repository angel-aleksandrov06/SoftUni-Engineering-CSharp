using System;
using System.Linq;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ");

            int lenthOfArray = array.Length;

            string[] comand = Console.ReadLine().Split(" ");

            while (comand[0] != "No" && comand[1] != "Money")
            {
                if (comand[0] == "OutOfStock")
                {
                    string searchName = comand[1];
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].Contains(searchName))
                            array[i] = "None";
                    }
                }

                else if (comand[0] == "Required")
                {
                    string comandIndexNumber = comand[2];
                    int indexNumber = int.Parse(comandIndexNumber);
                    string newName = comand[1];
                    if (indexNumber >= lenthOfArray || indexNumber < 0)
                    {
                        comand = Console.ReadLine().Split(" ");
                        continue;
                    }
                    array[indexNumber] = newName;
                }

                else if (comand[0] == "JustInCase")
                {
                    string newName = comand[1];
                    array[lenthOfArray - 1] = newName;
                }

                comand = Console.ReadLine().Split(" ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains("None"))
                {
                    continue;
                }
                Console.Write(array[i] + " ");
            }
        }
    }
}
