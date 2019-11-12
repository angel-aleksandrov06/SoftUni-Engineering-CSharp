namespace _08MilitaryElite.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Dictionary<int, IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public Dictionary<int, IPrivate> Privates { get; }
    }
}