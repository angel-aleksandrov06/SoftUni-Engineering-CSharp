namespace _08MilitaryElite.Contracts
{
    using _08MilitaryElite.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}