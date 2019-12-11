using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private const string MainPlayerNameKey = "Vercetti";
        private const string FullNameMainPlayer = "Tommy Vercetti";
        private List<IPlayer> players;
        private readonly GunRepository gunRepository;
        private readonly GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.players.Add(new MainPlayer());
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name);
                    break;
                case "Rifle":
                    gun = new Rifle(name);
                    break;
                default: return "Invalid gun type!";
            }

            this.gunRepository.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            if (name == MainPlayerNameKey)
            {
                IPlayer playerVercetti = this.players
                    .FirstOrDefault(x => x.Name == FullNameMainPlayer && x.GetType().Name == nameof(MainPlayer));

                IGun gunVercetti = this.gunRepository.Models.FirstOrDefault(x => x.CanFire == true);
                this.gunRepository.Remove(gunVercetti);

                playerVercetti.GunRepository.Add(gunVercetti);
                return $"Successfully added {gunVercetti.Name} to the Main Player: Tommy Vercetti";
            }

            if (this.players.FirstOrDefault(p => p.Name == name) == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            IPlayer player = this.players.FirstOrDefault(p => p.Name == name);
            IGun gun = this.gunRepository.Models.FirstOrDefault(g => g.CanFire == true);

            this.gunRepository.Remove(gun);
            player.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);

            this.players.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            MainPlayer mainPlayer = (MainPlayer)this.players.FirstOrDefault(p => p.GetType().Name == nameof(MainPlayer));

            List<IPlayer> civilPlayers = this.players.Where(p => p.GetType().Name != nameof(MainPlayer)).ToList();

            this.gangNeighbourhood.Action(mainPlayer, civilPlayers);

            var sb = new StringBuilder();

            if (civilPlayers.Any(x => x.IsAlive == true) && mainPlayer.LifePoints == 100)
            {
                sb.AppendLine("Everything is okay!");
            }
            else
            {
                sb.AppendLine("A fight happened:");

                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");

                sb.AppendLine($"Tommy has killed: {civilPlayers.Where(x => x.IsAlive == false).Count()} players!");

                sb.AppendLine($"Left Civil Players: {civilPlayers.Where(x => x.IsAlive == true).Count()}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
