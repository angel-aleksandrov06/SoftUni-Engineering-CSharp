﻿using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
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
                    if (input[0] == "AddPlayer")
                    {
                        Console.WriteLine(this.controller.AddPlayer(input[1]));
                    }
                    else if (input[0] == "AddGun")
                    {
                        Console.WriteLine(this.controller.AddGun(input[1], input[2]));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        Console.WriteLine(this.controller.AddGunToPlayer(input[1]));
                    }
                    else if (input[0] == "Fight")
                    {
                        Console.WriteLine(this.controller.Fight());
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