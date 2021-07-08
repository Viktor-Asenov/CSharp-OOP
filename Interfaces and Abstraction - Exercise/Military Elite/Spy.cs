namespace Military_Elite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName) 
            : base(id, firstName, lastName)
        {
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Code Number: {this.CodeNumber}";
        }
    }
}
