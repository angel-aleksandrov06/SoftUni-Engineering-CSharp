namespace _08MilitaryElite.Contracts
{
    using _08MilitaryElite.Enums;

    public interface IMission
    {
        public string CodeName { get; }

        public State State { get; }

        public void CompleteMission();
    }
}