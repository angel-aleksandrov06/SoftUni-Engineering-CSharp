namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PlanetRepository : IRepository<IPlanet>
    {
        public IReadOnlyCollection<IPlanet> Models => throw new NotImplementedException();

        public void Add(IPlanet model)
        {
            throw new NotImplementedException();
        }

        public IPlanet FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPlanet model)
        {
            throw new NotImplementedException();
        }
    }
}
