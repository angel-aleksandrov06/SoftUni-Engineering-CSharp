﻿namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.IO;
    using SpaceStation.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
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
                        string astronautType = input[1];
                        string astronautName = input[2];


                    }
                    else if (input[0] == "AddPlanet")
                    {

                    }
                    else if (input[0] == "RetireAstronaut")
                    {

                    }
                    else if (input[0] == "ExplorePlanet")
                    {

                    }
                    else if(input[0] == "Report")
                    {

                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

                //this.writer.WriteLine();
            }
        }
    }
}
