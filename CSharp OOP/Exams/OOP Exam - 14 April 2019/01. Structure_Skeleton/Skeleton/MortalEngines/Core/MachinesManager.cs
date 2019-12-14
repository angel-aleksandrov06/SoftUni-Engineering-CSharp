namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(x=>x.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);

            this.pilots.Add(pilot);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x=>x.Name == name && x.GetType().Name == nameof(Tank)))
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(tank);
            return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name && x.GetType().Name == nameof(Fighter)))
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);
            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            IMachine machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);
            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot == null)
            {
                pilot.AddMachine(machine);
                machine.Pilot = pilot;

                return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }
            else
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            IMachine defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);
            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints <=0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(x => x.Name == pilotReporting).Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(x => x.Name == machineName).ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.FirstOrDefault(x=>x.Name == fighterName && x.GetType().Name == nameof(Fighter)) == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            IFighter fighter = (Fighter)this.machines.FirstOrDefault(x => x.Name == fighterName && x.GetType().Name == nameof(Fighter));

            fighter.ToggleAggressiveMode();
            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.FirstOrDefault(x=>x.Name == tankName && x.GetType().Name == nameof(Tank)) == null)
            {
                return $"Machine {tankName} could not be found";
            }

            ITank tank = (Tank)this.machines.FirstOrDefault(x => x.Name == tankName && x.GetType().Name == nameof(Tank));

            tank.ToggleDefenseMode();
            return $"Tank {tankName} toggled defense mode";
        }
    }
}