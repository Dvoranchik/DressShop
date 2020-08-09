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
    public class CartTests
    {
        
        [TestMethod()]
        public void CartTest()
        {
            //arrange
            var customer = new Customer()
            {
                CustomerID = 1,
                Name = "testUser"
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
            var cart = new Cart(customer);

            var exprctedResult = new List<Product>()
            {
                product1, product1, product2
            };

            //act
            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);

            var cartResult = cart.GetAll();

            //assert
            Assert.AreEqual(exprctedResult.Count, cartResult.Count);
            for (int i = 0; i < exprctedResult.Count; i++)
            {
                Assert.AreEqual(exprctedResult[i], cartResult[i]);
            }
        }


    }
}