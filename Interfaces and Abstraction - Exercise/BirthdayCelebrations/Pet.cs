using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string birthday;

        public Pet(string birthday)
        {
            this.Birthday = birthday;
        }

        public string Birthday 
        {
            get => this.birthday;
            private set
            {
                if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                {
                    this.birthday = value;
                }
            }
        }

        public bool IsSameYearBorn(string year)
        {
            return this.Birthday.EndsWith(year);
        }
    }
}
