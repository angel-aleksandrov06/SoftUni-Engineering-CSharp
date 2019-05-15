using System;

namespace Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {

            int maxLettersSum = 0;
            string winerName = "";
            while(true)
            {
                string name = Console.ReadLine();


                if (name == "STOP")
                {
                    break;
                }

                int currentNameCharSum = 0;
                for (int i =0; i<name.Length; i++)
                {
                    int letter = name[i];
                    currentNameCharSum += letter; 
                    
                }
                if (currentNameCharSum>maxLettersSum)
                {
                    maxLettersSum = currentNameCharSum;
                    winerName = name;
                }



                if (name=="STOP")
                {
                    break;
                }
            }
           

            Console.WriteLine($"Winner is {winerName} - {maxLettersSum}!");
        }
    }
}
