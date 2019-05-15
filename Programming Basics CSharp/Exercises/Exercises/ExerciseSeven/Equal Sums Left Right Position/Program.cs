using System;

namespace Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                string currentNumber = i.ToString();
                int leftSum = 0;
                int rightSum = 0;

                int x0 = int.Parse(currentNumber[0] +"");
                int x1 = int.Parse(currentNumber[1] +"");
                int x2 = int.Parse(currentNumber[2] +"");
                int x3 = int.Parse(currentNumber[3] +"");
                int x4 = int.Parse(currentNumber[4] +"");

                leftSum = x0 + x1;
                rightSum = x3 + x4;
                
                if(leftSum!=rightSum)
                {
                    if(leftSum>rightSum)
                    {
                        rightSum += x2;
                    }
                    else if (rightSum>leftSum)
                    {
                        leftSum += x2;
                    }
                }
                if (leftSum == rightSum)
                {
                    Console.Write(i+" ");
                }
                





                
                

            }
        }
    }
}
