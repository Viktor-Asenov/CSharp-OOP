using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }

        public bool IsFake(string digits)
        {
            return this.Id.EndsWith(digits);
        }
    }
}
