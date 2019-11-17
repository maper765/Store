using System;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer 
    {
        public Customer(
            string firstName, 
            string lastName, 
            string document, 
            string email,
            string phone, 
            string address)
        {
            FirstName = firstName;
            lastName = LastName;
            document = Document;
            email = Email;
            phone = Phone;
            address = Address;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
    }
}