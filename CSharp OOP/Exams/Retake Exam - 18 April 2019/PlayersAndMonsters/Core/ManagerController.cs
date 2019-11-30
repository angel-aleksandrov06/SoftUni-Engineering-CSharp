namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
    using Factories.Contracts;
    using Common;
    using Models.Cards.Contracts;
    using Models.Players.Contracts;
    using Repositories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private ICardRepository cardRepository;
        private IBattleField battleField;

        public ManagerController(
            IPlayerFactory playerFactory, 
            IPlayerRepository playerRepository,
            ICardFactory cardFactory,
            ICardRepository cardRepository,
            IBattleField battleField
            )
        {
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            string result = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);

            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
