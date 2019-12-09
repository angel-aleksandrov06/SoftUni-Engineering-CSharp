namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Mission;
    using Models.Planets;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private readonly IMission mission;
        private int exploredPlanetCount;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanetCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            bool IsUnique = true;

            foreach (var item in this.astronautRepository.Models)
            {
                if (item.Name.Equals(astronautName))
                {
                    IsUnique = false;
                }
            }

            if (IsUnique)
            {
                this.astronautRepository.Add(astronaut);
            }

            return string.Format(OutputMessages.AstronautAdded,
                astronaut.GetType().Name,
                astronaut.Name);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            bool IsUnique = true;

            foreach (var item in this.planetRepository.Models)
            {
                if (item.Name.Equals(planetName))
                {
                    IsUnique = false;
                }
            }

            if (IsUnique)
            {
                planet.AddItems(items);
                this.planetRepository.Add(planet);
            }

            return string.Format(OutputMessages.PlanetAdded, planet.Name);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository.FindByName(planetName);
            this.mission.Explore(planet, astronauts);
            this.exploredPlanetCount++;

            return string.Format(OutputMessages.PlanetExplored, planet.Name, astronauts.Where(a => a.CanBreath == false).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanetCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Count == 0 ? "none" : string.Join(", ", astronaut.Bag.Items))} ");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (this.astronautRepository.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);
            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
