namespace Military_Elite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
        }

        public string Corps { get; private set; }
    }
}
