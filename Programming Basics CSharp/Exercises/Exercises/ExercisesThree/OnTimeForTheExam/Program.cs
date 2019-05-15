using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinutes;
            int arriveTime = arriveHour * 60 + arriveMinutes;

            if (arriveTime > examTime)
            {
                Console.WriteLine("Late");

                int late = arriveTime - examTime;
                if (late<60)
                {
                    Console.WriteLine($"{late} minutes after the start");
                }
                else
                {
                    int hourLate = late / 60;
                    int minuteslate = late % 60;

                    Console.WriteLine($"{hourLate}:{minuteslate:D2} hours after the start");
                }
            }
            else if (arriveTime == examTime || examTime-arriveTime <= 30)
            {
                Console.WriteLine("On time");

                int onTime = examTime - arriveTime;
                if (onTime<=30 && onTime !=0)
                {
                    Console.WriteLine($"{onTime} minutes before the start");
                }

            }
            else if (examTime-arriveTime > 30 )
            {
                Console.WriteLine("Early");
                int diff = examTime - arriveTime;

                if (examTime-arriveTime < 60)
                {                    
                    Console.WriteLine($"{diff} minutes before the start");
                }
                else
                {
                    int hour = diff / 60;
                    int minutes = diff % 60;

                    Console.WriteLine($"{hour}:{minutes:D2} hours before the start");
                }
            }
            
        }
    }
}
