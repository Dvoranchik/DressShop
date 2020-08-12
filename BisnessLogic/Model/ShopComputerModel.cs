using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Model
{
    public class ShopComputerModel
    { 
        Generator Generator = new Generator();
        Random random = new Random();
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();

        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var freeSellers = Generator.GetSellers(20);
            Generator.GetProducts(1000);
            Generator.GetCustomers(100);
            foreach (var seller in freeSellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = Generator.GetCustomers(10);
            var carts = new Queue<Cart>();

            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var product in Generator.GetRandomProducts(10,30))
                {
                    cart.Add(product);
                }
                carts.Enqueue(cart);

            }

            while (carts.Count>0)
            {
                var cash = CashDesks[random.Next(CashDesks.Count - 1)]; //TODO:
                cash.Enqueue(carts.Dequeue());
            }

            while (true)
            {
                var cash = CashDesks[random.Next(CashDesks.Count - 1)]; //TODO:
                var money = cash.Duqueue();
            }
        }
    }
}
