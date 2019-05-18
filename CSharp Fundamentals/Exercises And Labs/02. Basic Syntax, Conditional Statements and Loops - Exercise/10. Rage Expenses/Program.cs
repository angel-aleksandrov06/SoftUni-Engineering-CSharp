using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int counter = 0;
            int counterHeadset = 0;
            int counterMouse = 0;
            int counterKeyboard = 0;


            for (int i = 1; i <= lostGamesCount; i++)
            {
                counter++;
                if (i % 2==0)
                {
                    counterHeadset++;
                }
                if (i % 3 == 0)
                {
                    counterMouse++;
                }
                if(i%2==0 && i % 3 == 0)
                {
                    counterKeyboard++;
                }

            }
            headsetPrice = headsetPrice * counterHeadset;
            mousePrice = mousePrice * counterMouse;
            keyboardPrice = keyboardPrice * counterKeyboard;
            displayPrice = displayPrice * Math.Floor(counterKeyboard / 2.0);

            double expenses = headsetPrice + mousePrice + keyboardPrice + displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");

        }
    }
}
