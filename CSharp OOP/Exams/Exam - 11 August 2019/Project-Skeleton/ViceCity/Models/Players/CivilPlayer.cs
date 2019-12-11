namespace ViceCity.Models.Players
{
    using Contracts;

    public class CivilPlayer : Player, IPlayer
    {
        private const int DefaultLifePoints = 50;

        public CivilPlayer(string name) 
            : base(name, DefaultLifePoints)
        {
        }
    }
}
