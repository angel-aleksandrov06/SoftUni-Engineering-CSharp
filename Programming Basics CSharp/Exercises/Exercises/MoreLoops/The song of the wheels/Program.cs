using System;

namespace The_song_of_the_wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            int counter = 0;
            string password = "";

            for (int a  = 1;  a  <=9;  a ++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            bool a_b = a < b;
                            bool c_d = c > d;
                            int control = 0;
                            control = (a * b) + (c * d);
                            if(control==M && a_b && c_d)
                            {
                                counter++;
                                Console.Write($"{a}{b}{c}{d} ");
                                if (counter == 4)
                                {
                                    password = "" + a + b + c + d;
                                }
                            }
                            

                        }
                    }
                }
            }
            
            if (counter < 4)
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
            else
            {
                int passwordTwo = int.Parse(password);
                Console.WriteLine();
                Console.WriteLine($"Password: {passwordTwo}");
            }
        }
    }
}
