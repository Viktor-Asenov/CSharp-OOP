using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
        }

        public List<Private> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");

            foreach (var privateSoldier in this.Privates)
            {
                sb.AppendLine($"  {privateSoldier.ToString()}");
            }

            return sb.ToString();
        }
    }
}
