namespace MXGP.Models.Motorcycles
{
    using Contracts;
    using Utilities;
    using Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle, IMotorcycle
    {
        private const double DefaultCubicCentimeters = 125;
        private const int minHP = 50;
        private const int maxHP = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, DefaultCubicCentimeters)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                Validator.ThrowIfHorsePowerIsOutOfRange(value, minHP, maxHP, string.Format(ExceptionMessages.InvalidHorsePower, value));

                this.horsePower = value;
            }
        }
    }
}
