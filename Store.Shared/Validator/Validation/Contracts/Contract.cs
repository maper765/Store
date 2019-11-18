using Store.Shared.Validator.Notifications;

namespace Store.Shared.Validator.Validation.Contracts
{
    public abstract class Contract : Notifiable
    {
        protected Contract()
        {
            ValidationContract = new ValidationContract();
        }

        public ValidationContract ValidationContract { get; set; }
    }
}
