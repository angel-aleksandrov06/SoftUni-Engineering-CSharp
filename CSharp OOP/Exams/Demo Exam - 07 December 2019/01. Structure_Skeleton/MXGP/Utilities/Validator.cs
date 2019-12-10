namespace MXGP.Utilities
{
    using Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Validator
    {
        public static void ThrowIfLapsAreBelowOne(int value, string message = null)
        {
            if (value < 1)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStringIsNullOrWhiteSpaceOrIfIsLessThan4Symbols(string value, string message = null)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStringIsNullOrEmptyOrIfIsLessThan5Symbols(string value, string message = null)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 5)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfHorsePowerIsOutOfRange(int value, int minHP, int maxHP, string message = null)
        {
            if (value < minHP || value > maxHP)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfMotorcycleIsNull(IMotorcycle motorcycle, string message = null)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ThrowIfRiderIsNull(IRider rider, string message = null)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ThrowIfRiderDoesnotOwnMotorcycle(IRider rider, string message = null)
        {
            if (rider.CanParticipate == false)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfRiderAlreadyExistInTheRace(IRider rider, IReadOnlyCollection<IRider> riders, string message = null)
        {
            if (riders.Any(x=>x.Name == rider.Name))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
