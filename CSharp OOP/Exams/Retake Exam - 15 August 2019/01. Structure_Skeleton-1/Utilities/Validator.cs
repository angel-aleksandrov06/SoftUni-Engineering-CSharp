namespace SpaceStation.Utilities
{
    using System;

    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string value, string message = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
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
