namespace _08MilitaryElite.Models
{
    using System.Collections.Generic;

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
    }
}