using Store.Shared.Validator.Notifications;
using Store.Shared.Validator.Validation;

namespace Store.Domain.SharedContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(
            string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O e-mail é inválido")
            );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
