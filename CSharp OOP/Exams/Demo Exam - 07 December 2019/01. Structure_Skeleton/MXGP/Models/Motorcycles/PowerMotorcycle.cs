namespace MXGP.Models.Motorcycles
{
    using Contracts;
    using Utilities;
    using Utilities.Messages;

    public class PowerMotorcycle : Motorcycle, IMotorcycle
    {
        private const double DefaultCubicCentimeters = 450;
        private const int minHP = 70;
        private const int maxHP = 100;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
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
