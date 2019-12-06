namespace SpaceStation.Models.Astronauts
{
    using Contracts;

    public class Meteorologist : Astronaut, IAstronaut
    {
        private const double DefaultOxygenQuantity = 90.0;

        public Meteorologist(string name, double oxygen) 
            : base(name, oxygen)
        {
        }
    }
}
