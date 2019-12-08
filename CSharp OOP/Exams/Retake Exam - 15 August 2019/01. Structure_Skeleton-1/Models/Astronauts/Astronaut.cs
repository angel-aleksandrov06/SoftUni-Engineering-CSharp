namespace SpaceStation.Models.Astronauts
{
    using Contracts;
    using Bags;
    using Utilities;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;


        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidAstronautName);

                this.name = value;
                //TODO: Check IsUnique!!
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidOxygen);

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0.0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (this.Oxygen - 10 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 10;
            }
        }
    }
}
