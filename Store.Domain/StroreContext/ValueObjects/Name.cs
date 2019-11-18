using Store.Shared.Validator.Notifications;
using Store.Shared.Validator.Validation;

namespace Store.Domain.StroreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FristName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 100, "FristName", "O nome deve conter no máximo 100 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 100, "LastName", "O sobrenome deve conter no máximo 100 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
