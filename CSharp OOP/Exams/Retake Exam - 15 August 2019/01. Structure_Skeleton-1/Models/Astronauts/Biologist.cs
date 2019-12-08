namespace SpaceStation.Models.Astronauts
{
    using Contracts;

    public class Biologist : Astronaut, IAstronaut
    {
        private const double DefaultOxygenQuantity = 70.0;

        public Biologist(string name) 
            : base(name, DefaultOxygenQuantity)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 5;
            }
        }
    }
}
