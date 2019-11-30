namespace PlayersAndMonsters.Models.Players
{
    using System;

    using Common;
    using Contracts;
    using Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get { return this.username; }
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidUsername);

                this.username = value;
            }
        }

        public int Health 
        {
            get { return this.health; } 
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.InvalidUserHealt);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <=0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(damagePoints, ExceptionMessages.InvalidDamagePoints);

            this.Health = Math.Max(this.Health - damagePoints, 0);
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.PlayerReportInfo, 
                this.username, 
                this.health, 
                this.CardRepository.Count);
        }
    }
}
