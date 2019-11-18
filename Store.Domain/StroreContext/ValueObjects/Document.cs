using Store.Shared.Validator.Notifications;
using Store.Shared.Validator.Validation;

namespace Store.Domain.StroreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(
            string number)
        {
            Number = number;

            AddNotifications(new ValidationContract()
                .IsCpf(number, "CPF", "O CPF é inválido")
            );
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }
    }
}
