using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)this.models;
        }

        public T GetByName(string name)
        {
            return this.models.FirstOrDefault(m => nameof(m).Equals(name));
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
