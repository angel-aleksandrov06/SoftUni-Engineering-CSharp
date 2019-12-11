namespace ViceCity.Models.Players
{
    using Contracts;

    public class MainPlayer : Player, IPlayer
    {
        private const int DefaultLifePoints = 100;
        private const string DefaultName = "Tommy Vercetti";

        public MainPlayer() 
            : base(DefaultName, DefaultLifePoints)
        {
        }
    }
}
