namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Guns.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.models.Any(x=>x.Name == model.Name))
            {
                models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = this.models.FirstOrDefault(x => x.Name == name);

            return gun;
        }

        public bool Remove(IGun model)
        {
            IGun gun = this.models.FirstOrDefault(x => x.Name == model.Name);

            if (gun != null)
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
