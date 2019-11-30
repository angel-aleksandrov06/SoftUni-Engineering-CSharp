namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;
    using Cards.Contracts;
    using Common;
    using Contracts;
    using Players;
    using Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }

            if (attackPlayer is Beginner)
            {
                this.BoostBeginnerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.BoostBeginnerPlayer(enemyPlayer);
            }

            BoostPlayer(attackPlayer);

            BoostPlayer(enemyPlayer);

            int attackPlayerDamage = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
            int enemyPlyaerDamage = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);


            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlyaerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BoostPlayer(IPlayer player)
        {
            int attackPlayerBonusHealth = player.CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            player.Health += attackPlayerBonusHealth;
        }

        private void BoostBeginnerPlayer(IPlayer player)
        {

            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
