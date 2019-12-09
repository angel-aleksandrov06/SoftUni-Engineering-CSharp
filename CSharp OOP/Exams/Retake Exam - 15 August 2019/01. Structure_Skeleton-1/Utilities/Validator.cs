namespace SpaceStation.Utilities
{
    using System;

    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string value, string message = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ThrowIfIntegerIsBelowZero(double value, string message = null)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
