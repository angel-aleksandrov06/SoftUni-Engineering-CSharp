using System;

namespace _6._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            if(comand=="England" || comand == "USA")
            {
                Console.WriteLine("English");
            }
            else if(comand=="Spain" || comand=="Argentina" || comand=="Mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
