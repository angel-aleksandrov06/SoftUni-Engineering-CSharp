namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorationRepository = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;
                case "Plant":
                    decoration = new Plant();
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorationRepository.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType); ;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string typeOfAquaruimForCurrentFish = string.Empty;

            if (fish.GetType().Name == nameof(FreshwaterFish))
            {
                typeOfAquaruimForCurrentFish = "FreshwaterAquarium";
            }
            else if (fish.GetType().Name == nameof(SaltwaterFish))
            {
                typeOfAquaruimForCurrentFish = "SaltwaterAquarium";
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (aquarium.GetType().Name != typeOfAquaruimForCurrentFish)
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.FishAdded, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            decimal totalPrice = 0;

            if (this.aquariums.Any(x=>x.Name == aquariumName))
            {
                IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

                decimal priceOfFish = aquarium.Fish.Sum(x => x.Price);

                decimal priceOfdecorations = aquarium.Decorations.Sum(x => x.Price);

                totalPrice = priceOfdecorations + priceOfFish;
            }
            return $"The value of Aquarium {aquariumName} is {totalPrice:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            this.aquariums.FirstOrDefault(x => x.Name == aquariumName).Feed();
            int fishCount = this.aquariums.FirstOrDefault(x => x.Name == aquariumName).Fish.Count;

            return string.Format(OutputMessages.FishFed, fishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (!this.decorationRepository.Models.Any(x=>x.GetType().Name == decorationType))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IDecoration decoration = this.decorationRepository.Models.FirstOrDefault(x => x.GetType().Name == decorationType);
            this.decorationRepository.Remove(decoration);

            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);

            return string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
