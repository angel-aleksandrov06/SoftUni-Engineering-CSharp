using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNames = Console.ReadLine().Split(", ");
            var filteredNames = inputNames.Where(x => x.Length > 3 && x.Length < 16).ToList();

            var list = new List<string>();

            foreach (var item in filteredNames)
            {
                var isValidUsername = true;

                for (int i = 0; i < item.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(item[i]) && item[i] != '_' && item[i] != '-')
                    {
                        isValidUsername = false;
                        break;
                    }
                }

                if (isValidUsername)
                {
                    list.Add(item);
                }
            }

            foreach (var username in list)
            {
                Console.WriteLine(username);
            }
        }
    }
}
