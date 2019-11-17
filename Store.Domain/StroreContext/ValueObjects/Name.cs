namespace Store.Domain.StroreContext.ValueObjects
{
    public class Name
    {
        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            lastName = LastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
