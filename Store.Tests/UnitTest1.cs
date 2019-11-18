using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StroreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Mario", "Oliveira");
            var document = new Document("12345678910");
            var email = new Email("teste@email.com");
            var c = new Customer(
                name,
                document,
                email,
                "14789-8585");

            var teclado = new Product("Teclado mecânico", "Teclado RGB", "imag.png", 109.90M, 2);
            var mousePad = new Product("MousePadr", "Mouse Pad 70cm", "imag.png", 95.90M, 2);
            var mouse = new Product("Mouse", "Mouse Gamer", "imag.png", 209.90M, 1);
            var monitor = new Product("Monitor Ultra Wide", "Monitor 29'", "imag.png", 1009.90M, 1);

            var order = new Order(c);
            order.AddItem(new OrderItem(teclado, 2));
            order.AddItem(new OrderItem(mousePad, 2));
            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(monitor, 2));

            // Realizar pedido
            order.Place();

            // Simular pagamento
            order.Pay();

            // Simular envio
            order.Ship();

            // Simular cancelamento
            order.Cancel();
        }
    }
}
