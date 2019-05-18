using System;

namespace _4._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            char[] cArray = comand.ToCharArray();
            string reversed = string.Empty;
            for (int i = cArray.Length-1; i > -1; i--)
            {
                reversed += cArray[i];
            }

            Console.WriteLine(reversed);
        }
    }
}
