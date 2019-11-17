using Store.Domain.StroreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.StoreContext.Entities
{
    public class Order 
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _delivaries;

        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _delivaries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Delivaries => _delivaries.ToArray();

        public void AddItem(OrderItem item)
        {
            //Valida item
            _items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            _delivaries.Add(delivery);
        }

        // To Place An Order
        public void Place()
        {
            
        }
    }
}