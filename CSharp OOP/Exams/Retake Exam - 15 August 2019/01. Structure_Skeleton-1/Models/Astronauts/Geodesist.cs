namespace SpaceStation.Models.Astronauts
{
    using Contracts;

    public class Geodesist: Astronaut, IAstronaut
    {
        private const int DefaultOxygenQuantity = 50;

        public Geodesist(string name)
            : base(name, DefaultOxygenQuantity)
        {
        }
    }
}
