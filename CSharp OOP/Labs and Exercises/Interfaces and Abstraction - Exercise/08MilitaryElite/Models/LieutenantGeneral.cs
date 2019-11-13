namespace _08MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Dictionary<int, IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public Dictionary<int, IPrivate> Privates { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Privates:");

            foreach (var currentPrivate in this.Privates)
            {
                stringBuilder.AppendLine("  " + currentPrivate.Value.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}