using System;

namespace _5._Login
{
    class Program
    {
        static void Main(string[] args)
        {

            string username = Console.ReadLine();
            int counter = 0;

            while (counter <= 3)
            {
                string str = "", reverse = "";
                int Length = 0;
                str = Console.ReadLine();

                Length = str.Length - 1;
                while (Length >= 0)
                {
                    reverse = reverse + str[Length];
                    Length--;
                }
                
                
                if (reverse != username && counter<3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    counter++;
                    
                }
                else if(reverse != username && counter == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"User {username} logged in.");
                    counter = 0;
                    break;
                }
                
            }
            if (counter >= 3)
                Console.WriteLine($"User {username} blocked!");

        }
    }
}
