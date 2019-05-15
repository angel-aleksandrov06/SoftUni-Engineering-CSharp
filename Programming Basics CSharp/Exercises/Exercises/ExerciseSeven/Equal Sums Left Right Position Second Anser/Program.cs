using System;



namespace ConsoleApp11

{

    class Program

    {

        static void Main(string[] args)

        {

            int first = int.Parse(Console.ReadLine());

            int second = int.Parse(Console.ReadLine());



            for (int i = first; i <= second; i++)

            {

                int leftsum = 0;

                int rightsum = 0;

                int current = i;

                int midnum = 0;



                for (int j = 5; j >= 1; j--)

                {

                    int thisnum = current % 10;

                    current /= 10;



                    if (j == 5 || j == 4)

                    {

                        rightsum += thisnum;

                    }

                    else if (j == 1 || j == 2)

                    {

                        leftsum += thisnum;

                    }
                    else

                    {

                        midnum = thisnum;

                    }



                }

                if (rightsum < leftsum)

                {

                    rightsum += midnum;

                }

                else if (leftsum < rightsum)

                {

                    leftsum += midnum;

                }





                if (leftsum == rightsum)

                {

                    Console.Write(i + " ");

                }





            }

        }

    }

}