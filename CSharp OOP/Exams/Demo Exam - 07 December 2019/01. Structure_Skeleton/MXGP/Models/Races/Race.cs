namespace MXGP.Models.Races
{
    using System.Collections.Generic;

    using Contracts;
    using MXGP.Utilities;
    using MXGP.Utilities.Messages;
    using Riders.Contracts;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
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

        public int Laps 
        {
            get => this.laps;
            private set
            {
                Validator.ThrowIfLapsAreBelowOne(value, string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            Validator.ThrowIfRiderIsNull(rider, ExceptionMessages.RiderInvalid);

            Validator.ThrowIfRiderDoesnotOwnMotorcycle(rider, string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));

            Validator.ThrowIfRiderAlreadyExistInTheRace(rider, Riders, string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));

            riders.Add(rider);
        }
    }
}
