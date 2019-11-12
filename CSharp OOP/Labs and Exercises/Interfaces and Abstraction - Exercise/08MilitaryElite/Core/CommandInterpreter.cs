namespace _08MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<ISoldier> soldiers;

        public CommandInterpreter()
        {
            this.soldiers = new List<ISoldier>();
        }

        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            if (soldierType == "Private")
            {
                var salary = decimal.Parse(args[4]);
                var soldier = new Private(id, firstName, lastName, salary);
                this.soldiers.Add(soldier);
            }



            throw new NotImplementedException();
        }
    }
}
