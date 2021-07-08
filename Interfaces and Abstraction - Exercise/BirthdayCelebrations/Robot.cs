using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public Robot(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }

        public bool GetId(string numbers)
        {
            return this.Id.EndsWith(numbers);
        }
    }
}
