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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExeptionMessages.InvalidUsername);
                }

                this.username = value;
            }
        }

        public int Health 
        {
            get { return this.health; } 
            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExeptionMessages.InvalidUserHealt);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <=0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(damagePoints, ExeptionMessages.InvalidDamagePoints);

            this.Health = Math.Max(this.Health - damagePoints, 0);
        }
    }
}
