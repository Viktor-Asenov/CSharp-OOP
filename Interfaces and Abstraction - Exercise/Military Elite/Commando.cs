using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
        }

        public List<Mission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {

            }
            return sb.ToString();
        }
    }
}
