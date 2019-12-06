using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        public ICollection<string> Items => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();
    }
}
