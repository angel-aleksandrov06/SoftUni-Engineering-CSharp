﻿namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;
    using Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            this.playersByName = new Dictionary<string, IPlayer>();
        }

        public int Count => this.playersByName.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playersByName.Values.ToList();

        public void Add(IPlayer player)
        {
            Validator.ThrowIfPlayerIsNull(player, ExceptionMessages.NullPlayer);

            if (this.playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExists, player.Username));
            }

            this.playersByName.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (this.playersByName.ContainsKey(username))
            {
                player = this.playersByName[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            Validator.ThrowIfPlayerIsNull(player, ExceptionMessages.NullPlayer);

            bool hasRemoved = this.playersByName.Remove(player.Username);

            return hasRemoved;
        }
    }
}