using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly MotorcycleRepository<IMotorcycle> motorcycleRepository;
        private readonly RaceRepository<IRace> raceRepository;
        private readonly RiderRepository<IRider> riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository<IMotorcycle>();
            this.raceRepository = new RaceRepository<IRace>();
            this.riderRepository = new RiderRepository<IRider>();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (!riderRepository.Models.Any(x=>x.Name == riderName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (!motorcycleRepository.Models.Any(x=>x.Model == motorcycleModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            IRider rider = this.riderRepository.Models.FirstOrDefault(x => x.Name == riderName);
            IMotorcycle motorcycle = this.motorcycleRepository.Models.FirstOrDefault(x => x.Model == motorcycleModel);
            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (!raceRepository.Models.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!riderRepository.Models.Any(x => x.Name == riderName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IRider rider = this.riderRepository.Models.FirstOrDefault(x => x.Name == riderName);
            IRace race = this.raceRepository.Models.FirstOrDefault(x => x.Name == raceName);
            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            if (motorcycleRepository.Models.Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            this.motorcycleRepository.Add(motorcycle);
            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.Models.Any(x=>x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            Rider rider = new Rider(riderName);
            if (riderRepository.Models.Any(x=>x.Name == riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            riderRepository.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            if (!this.raceRepository.Models.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = this.raceRepository.Models.FirstOrDefault(x => x.Name == raceName);

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var bestThreRiders = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).Take(3);
            raceRepository.Remove(race);

            var sb = new StringBuilder();
            int counter = 0;

            foreach (var rider in bestThreRiders)
            {
                if (counter == 0 )
                {
                    sb.AppendLine($"Rider {rider.Name} wins {raceName} race.");
                    rider.WinRace();
                }

                else if (counter == 1)
                {
                    sb.AppendLine($"Rider {rider.Name} is second in {raceName} race.");
                }

                else if (counter == 2)
                {
                    sb.AppendLine($"Rider {rider.Name} is third in {raceName} race.");
                }
                counter++;
            }
            return sb.ToString().TrimEnd();
        }
    }
}
