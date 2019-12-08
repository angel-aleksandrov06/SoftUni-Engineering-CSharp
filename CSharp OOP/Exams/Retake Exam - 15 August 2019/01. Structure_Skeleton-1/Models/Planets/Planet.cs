namespace SpaceStation.Models.Planets
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Utilities;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.Items = new Collection<string>();
        }

        public ICollection<string> Items { get; private set; }

        public string Name
        {
            get => this.name;

            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidPlanetName);
            }
        }
    }
}
