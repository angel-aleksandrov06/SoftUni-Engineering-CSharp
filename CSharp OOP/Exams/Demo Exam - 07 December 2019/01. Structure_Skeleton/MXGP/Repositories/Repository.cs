namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Repository<T> : IRepository<T>
    {
        private List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public List<T> Models
        {
            get => this.models;
            private set
            {
                this.models = value;
            }
        }

        public void Add(T model)
        {
            this.models.Add(model);

        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public T GetByName(string name)
        {
            foreach (var entity in this.models)
            {
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.Name == "Name")
                    {
                        var value = prop.GetValue(entity, null);
                        if (value.ToString() == name)
                        {
                            return entity;
                        }
                    }
                }
            }
            return default(T);
        }

        public bool Remove(T model)
        {
            T toRemove = this.models.First(x => x.Equals(model));
            if (toRemove != null)
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
