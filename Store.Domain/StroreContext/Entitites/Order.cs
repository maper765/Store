using Store.Domain.StroreContext.Enums;
using Store.Shared.Validator.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _delivaries;

        public Order(Customer customer)
        {
            Customer = customer;
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

        // Criar um pedido
        public void Place()
        {
            // Gera o número do pedido
            Number = Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, 8).ToUpper();

            if (_items.Count == 0)
                AddNotification("Pedido", "Este pedido não possui itens");
        }

        // Pagar um pedido
        public void Pay()
        {
            // Para fins de estudo, assume-se que o pagamento já foi realizado...
            Status = EOrderStatus.Paid;
        }

        // Enviar um pedido
        public void Ship()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            // Quebra as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            // Envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            // Adiciona as entregas ao pedido
            deliveries.ForEach(x => _delivaries.Add(x));
        }

        // Cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _delivaries.ToList().ForEach(x => x.Cancel());
        }
    }
}