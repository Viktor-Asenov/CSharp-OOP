using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private ICollection<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>)this.models;

        public void Add(IBunny model)
        {
            this.models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            if (this.models.Any(m => m.Name == name))
            {
                IBunny bunny = this.models.FirstOrDefault(m => m.Name == name);
                return bunny;
            }

            return null;
        }

        public bool Remove(IBunny model)
        {
            if (this.models.Any(m => m.Name == model.Name))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
