namespace ViceCity.Models.Players
{
    using System;

    using Contracts;
    using Guns.Contracts;
    using Repositories.Contracts;
    using ViceCity.Repositories;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.IsAlive = true;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Player's {value} cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }

        public bool IsAlive{ get; private set;}

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points < 0)
            {
                this.LifePoints = 0;
                this.IsAlive = false;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}
