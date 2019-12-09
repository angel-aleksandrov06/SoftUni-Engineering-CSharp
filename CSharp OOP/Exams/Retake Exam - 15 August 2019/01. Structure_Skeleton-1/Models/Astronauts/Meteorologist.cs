namespace SpaceStation.Models.Astronauts
{
    using Contracts;

    public class Meteorologist : Astronaut, IAstronaut
    {
        private const int DefaultOxygenQuantity = 90;

        public Meteorologist(string name) 
            : base(name, DefaultOxygenQuantity)
        {
        }
    }
}
