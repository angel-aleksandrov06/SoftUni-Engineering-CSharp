namespace MXGP.Models.Riders
{
    using Contracts;
    using Motorcycles.Contracts;
    using Utilities;
    using Utilities.Messages;

    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmptyOrIfIsLessThan5Symbols(value, string.Format(ExceptionMessages.InvalidName, value, 5));

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                if (this.Motorcycle == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            Validator.ThrowIfMotorcycleIsNull(motorcycle, ExceptionMessages.MotorcycleInvalid);

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
