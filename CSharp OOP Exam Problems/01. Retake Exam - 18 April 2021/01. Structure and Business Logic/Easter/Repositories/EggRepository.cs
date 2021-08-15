using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private ICollection<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)this.models;

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
        {
            if (this.models.Any(m => m.Name == name))
            {
                IEgg egg = this.models.FirstOrDefault(m => m.Name == name);
                return egg;
            }

            return null;
        }

        public bool Remove(IEgg model)
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
