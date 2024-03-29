using Store.Shared.Validator.Notifications;
using System;
using System.Collections.Generic;

namespace Store.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(
            Product product,
            decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantidade", "Produto fora de estoque");
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        //public IDictionary<string, string> Notifications { get; set; }
    }
}