namespace _08MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Enums;
    using Models;

    public class CommandInterpreter : ICommandInterpreter
    {
        private Dictionary<int, ISoldier> soldiers;

        public CommandInterpreter()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }

        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                var salary = decimal.Parse(args[4]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                var salary = decimal.Parse(args[4]);
                var privates = new Dictionary<int, IPrivate>();

                for (int i = 5; i < args.Length; i++)
                {
                    int soldierId = int.Parse(args[i]);
                    var currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);
                }
                soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            }
            else if (soldierType == "Engineer")
            {
                var salary = decimal.Parse(args[4]);

                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    return null;
                }

                ICollection<IRepair> repairs = new List<IRepair>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    string currentName = args[i];
                    int hours = int.Parse(args[i + 1]);

                    IRepair repair = new Repair(currentName, hours);
                    repairs.Add(repair);
                }

                soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            }
            else if (soldierType == "Commando")
            {
                var salary = decimal.Parse(args[4]);

                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    return null;
                }

                ICollection<IMission> missions = new List<IMission>();

                for (int i = 6; i < args.Length; i += 2)
                {
                    string missionName = args[i];
                    string missionState = args[i + 1];

                    bool isValidMissionState = Enum.TryParse<State>(missionState, out State state);

                    if (!isValidMissionState)
                    {
                        continue;
                    }

                    IMission mission = new Mission(missionName, state);
                    missions.Add(mission);
                }

                soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(args[3]);
                soldier = new Spy(id, firstName, lastName, codeNumber);
                
            }
            this.soldiers.Add(id, soldier);

            return soldier.ToString();
        }
    }
}
