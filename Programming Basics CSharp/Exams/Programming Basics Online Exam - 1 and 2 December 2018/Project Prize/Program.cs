using System;

namespace Project_Prize
{
    class Program
    {
        static void Main(string[] args)
        {
            int parstProject = int.Parse(Console.ReadLine());
            double moneyGiftForOnePunkt = double.Parse(Console.ReadLine());
            
            int punkts = 0;

            for (int i = 1; i <= parstProject; i++)
            {
                int punktsOFStage = int.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    punkts += punktsOFStage;
                }else if (i % 2 == 0)
                {
                    punkts += punktsOFStage * 2;
                }
            }
            double sum = moneyGiftForOnePunkt * punkts;
            Console.WriteLine($"The project prize was {sum:F2} lv.");
        }
    }
}
