using Store.Shared.Validator.Notifications;

namespace Store.Shared.Validator.Validation
{
    public partial class ValidationContract : Notifiable
    {
        public ValidationContract Requires()
        {
            return this;
        }

        public ValidationContract Concat(Notifiable notifiable)
        {
            if (notifiable.Invalid)
                AddNotifications(notifiable.Notifications);

            return this;
        }
    }
}
