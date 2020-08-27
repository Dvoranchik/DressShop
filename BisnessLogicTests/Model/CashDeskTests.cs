using Microsoft.VisualStudio.TestTools.UnitTesting;
using BisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {


            //arrange
            var customer1 = new Customer()
            {
                Name = "testUser",
                CustomerID = 1
            };

            var customer2 = new Customer()
            {
                Name = "testUser",
                CustomerID = 2
            };

            var seller = new Seller()
            {
                Name = "seller1",
                SellerId = 1
            };
            var product1 = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };
            var product2 = new Product()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };
            var cart1 = new Cart(customer1);
            var cart2 = new Cart(customer2);

            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);

            var cashdesk = new CashDesk(1, seller, null);
            cashdesk.MaxQueueLenght = 10;
            cashdesk.Enqueue(cart1);
            cashdesk.Enqueue(cart2);

            var cart2ExpectedResult = 500;
            var cart1ExpectedResult = 400;


            //act
            var cartActualResult1 = cashdesk.Duqueue();
            var cartActualResult2 = cashdesk.Duqueue();


            //assert
            Assert.AreEqual(cart1ExpectedResult, cartActualResult1);
            Assert.AreEqual(cart2ExpectedResult, cartActualResult2);
        }


    }
}