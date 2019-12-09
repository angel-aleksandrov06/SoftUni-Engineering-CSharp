namespace SpaceStation.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        Console.WriteLine(this.controller.AddAstronaut(input[1], input[2]));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        Console.WriteLine(this.controller.AddPlanet(input[1], input.Skip(2).ToArray()));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        Console.WriteLine(this.controller.RetireAstronaut(input[1]));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        Console.WriteLine(this.controller.ExplorePlanet(input[1]));
                    }
                    else if(input[0] == "Report")
                    {
                        Console.WriteLine(this.controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
