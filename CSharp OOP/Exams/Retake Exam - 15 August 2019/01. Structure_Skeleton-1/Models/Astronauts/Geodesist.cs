namespace SpaceStation.Models.Astronauts
{
    using Contracts;

    public class Geodesist: Astronaut, IAstronaut
    {
        private const double DefaultOxygenQuantity = 50.0;

        public Geodesist(string name)
            : base(name, DefaultOxygenQuantity)
        {
        }
    }
}
