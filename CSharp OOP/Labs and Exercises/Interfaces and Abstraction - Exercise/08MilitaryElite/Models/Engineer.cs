﻿namespace _08MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Enums;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Corps: {this.Corps}");
            stringBuilder.AppendLine("Repairs:");

            foreach (var currentRepair in this.Repairs)
            {
                stringBuilder.AppendLine("  " + currentRepair.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}