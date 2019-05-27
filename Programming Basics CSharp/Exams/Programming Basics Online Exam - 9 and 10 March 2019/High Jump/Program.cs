using System;

namespace High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int jelanaVisochina = int.Parse(Console.ReadLine());
            string comand = Console.ReadLine();
            int visochina = 0;
            int nachalnaVisochina = jelanaVisochina - 30;
            int countJumps = 0;
            int counFailJumps = 0;
            int visochinaNaPruta = nachalnaVisochina;


            while (comand!="")
            {
                if (comand == null)
                {
                    break;
                }
                visochina = int.Parse(comand);
                if (visochina > visochinaNaPruta)
                {
                    visochinaNaPruta += 5;
                    countJumps++;
                    counFailJumps = 0;

                }
                else
                {
                    countJumps++;
                    counFailJumps++;
                }
                if (counFailJumps == 3)
                {
                    Console.WriteLine($"Tihomir failed at {visochinaNaPruta}cm after {countJumps} jumps.");
                    break;
                }
                
                comand = Console.ReadLine();
                
            }
            if (visochina > jelanaVisochina && counFailJumps<3)
            {
                int visochinaNaPoslednataLetva = visochinaNaPruta - 5;
                Console.WriteLine($"Tihomir succeeded, he jumped over {visochinaNaPoslednataLetva}cm after {countJumps} jumps.");
               
            }
        }
    }
}
