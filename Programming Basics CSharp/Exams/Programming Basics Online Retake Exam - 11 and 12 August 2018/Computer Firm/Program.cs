using System;

namespace Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double averageRate = 0;
            
            
           
            int rating = 0;
            int ratingSum = 0;

            int seling = 0;
            double selss = 0;
            double sellsSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                string numberAsString = number.ToString();
                     rating = int.Parse(numberAsString[2] + "");
                char secondNumber = numberAsString[1];
                char firstNumber = numberAsString[0];
                string chislo = "" + firstNumber + secondNumber;
                    seling = int.Parse(chislo + "");
                ratingSum += rating;
                
                
                switch (rating)
                {
                    case 2:
                        selss = 0;
                        break;
                    case 3:
                        selss = 0.50 * seling;
                        break;
                    case 4:
                        selss =  0.70 * seling;
                        break;
                    case 5:
                        selss =  0.85 * seling;
                        break;
                    case 6:
                        selss = seling;
                        break;
                    default:
                        break;
                    
                }
                sellsSum += selss;
            }
            averageRate = ratingSum * 1.0 / n;
            
            Console.WriteLine($"{sellsSum:F2}");
            Console.WriteLine($"{averageRate:F2}");
            
        }
    }
}
