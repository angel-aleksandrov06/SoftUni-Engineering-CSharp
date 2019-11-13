namespace _08MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Enums;

    class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Corps: {this.Corps}");
            stringBuilder.AppendLine("Missions:");

            foreach (var currentMission in this.Missions)
            {
                stringBuilder.AppendLine("  " + currentMission.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}