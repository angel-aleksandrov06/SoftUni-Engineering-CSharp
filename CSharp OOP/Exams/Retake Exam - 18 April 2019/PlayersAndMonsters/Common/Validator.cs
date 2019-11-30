namespace PlayersAndMonsters.Common
{
    using System;

    using Models.Cards.Contracts;
    using Models.Players.Contracts;

    public static class Validator
    {
        public static void ThrowIfIntegerIsBelowZero(int value, string message = null)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(string value, string message = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfCardIsNull(ICard card, string message)
        {
            if (card == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfPlayerIsNull(IPlayer player, string message)
        {
            if (player == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
