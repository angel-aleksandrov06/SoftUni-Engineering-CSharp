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
        private BackPack backPack;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
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

        public bool CanBreath => this.oxygen > 0.0;

        public IBag Bag
        {
            get => this.backPack;
            private set
            {
                //TODO: Check Is it Okay???
                if (value.GetType().Name == "BackPack")
                {
                    this.backPack = (BackPack)value;
                }
            }
        }

        public virtual void Breath()
        {
            this.Oxygen -= 10.0;

            if (this.Oxygen < 0.0)
            {
                this.Oxygen = 0.0;
            }
        }
    }
}
