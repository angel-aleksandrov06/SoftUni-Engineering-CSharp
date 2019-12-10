
namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IChampionshipController championshipController;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }

                try
                {
                    if (input[0] == "CreateRider")
                    {
                        Console.WriteLine(this.championshipController.CreateRider(input[1]));
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        string motorcycleType = input[1];
                        string model = input[2];
                        int horsePower = int.Parse(input[3]);

                        Console.WriteLine(this.championshipController.CreateMotorcycle(motorcycleType, model, horsePower));
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        string riderName = input[1];
                        string motorcycleName = input[2];

                        Console.WriteLine(this.championshipController.AddMotorcycleToRider(riderName, motorcycleName));
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        string raceName = input[1];
                        string riderName = input[2];

                        Console.WriteLine(this.championshipController.AddRiderToRace(raceName, riderName));
                    }
                    else if (input[0] == "CreateRace")
                    {
                        string name = input[1];
                        int laps = int.Parse(input[2]);
                        Console.WriteLine(this.championshipController.CreateRace(name, laps));
                    }
                    else if (input[0] == "StartRace")
                    {
                        Console.WriteLine(this.championshipController.StartRace(input[1]));
                    }
                }
                catch (Exception ex )
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
