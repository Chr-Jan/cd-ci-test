namespace ValidateTheNameModelBinding.Models
{
    public class Person
    {
        private Firstname firstName;
        private Lastname lastName;

        public Person(Firstname firstName, Lastname lastName)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public override string ToString() => $"{firstName} {lastName}";
    }
}
