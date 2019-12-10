namespace MXGP.Models.Motorcycles
{
    using Contracts;
    using Utilities;
    using Utilities.Messages;

    public abstract class Motorcycle : IMotorcycle
    {
        private string model;

        public Motorcycle(string model, double cubicCentimeters)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model 
        {
            get => this.model;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpaceOrIfIsLessThan4Symbols(value, string.Format(ExceptionMessages.InvalidModel, value, 4));

                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double result = this.CubicCentimeters / this.HorsePower * laps;

            return result;
        }
    }
}
