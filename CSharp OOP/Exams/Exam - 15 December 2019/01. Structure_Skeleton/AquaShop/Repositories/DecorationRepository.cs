﻿using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(x => x.GetType().Name == nameof(type));
        }

        public bool Remove(IDecoration model)
        {
            if (this.decorations.Any(x=>x.Comfort == model.Comfort && x.Price == model.Price))
            {
                this.decorations.Remove(model);
                return true;
            }

            return false;
        }
    }
}