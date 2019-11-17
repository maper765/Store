using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "Mario",
                "Oliveira",
                "12345678910",
                "mario@email.com",
                "14789-8585",
                "Rua testando");

        }
    }
}
