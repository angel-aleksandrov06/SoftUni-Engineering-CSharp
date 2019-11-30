namespace PlayersAndMonsters.Models.Cards
{
    using Contracts;
    using Common;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty( value, ExceptionMessages.InvalidCardName );

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get { return this.damagePoints; }
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidCardDamagePoints);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get { return this.healthPoints; }
            private set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidCardHealthPoints);

                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.CardReportInfo,
                this.Name,
                this.DamagePoints);
        }
    }
}
