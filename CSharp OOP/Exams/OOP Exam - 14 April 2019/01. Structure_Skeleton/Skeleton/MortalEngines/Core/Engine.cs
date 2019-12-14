using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IMachinesManager machinesManager;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter(); ;
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                if (input[0] == "Quit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "HirePilot")
                    {
                        Console.WriteLine(this.machinesManager.HirePilot(input[1]));
                    }
                    else if (input[0] == "PilotReport")
                    {
                        Console.WriteLine(this.machinesManager.PilotReport(input[1]));
                    }
                    else if (input[0] == "ManufactureTank")
                    {
                        var name = input[1];
                        var attack = double.Parse(input[2]);
                        var defense = double.Parse(input[3]);

                        Console.WriteLine(this.machinesManager.ManufactureTank(name, attack, defense));
                    }
                    else if (input[0] == "ManufactureFighter")
                    {
                        var name = input[1];
                        var attack = double.Parse(input[2]);
                        var defense = double.Parse(input[3]);

                        Console.WriteLine(this.machinesManager.ManufactureFighter(name, attack, defense));
                    }
                    else if (input[0] == "MachineReport")
                    {
                        Console.WriteLine(this.machinesManager.MachineReport(input[1]));
                    }
                    else if (input[0] == "AggressiveMode")
                    {
                        Console.WriteLine(this.machinesManager.ToggleFighterAggressiveMode(input[1]));
                    }
                    else if (input[0] == "DefenseMode")
                    {
                        Console.WriteLine(this.machinesManager.ToggleTankDefenseMode(input[1]));
                    }
                    else if (input[0] == "Engage")
                    {
                        Console.WriteLine(this.machinesManager.EngageMachine(input[1], input[2]));
                    }
                    else if (input[0] == "Attack")
                    {
                        Console.WriteLine(this.machinesManager.AttackMachines(input[1], input[2]));
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
