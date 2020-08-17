using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BisnessLogic.Model
{
    public class ShopComputerModel
    { 
        Generator Generator = new Generator();
        Random random = new Random();
        private bool isWorking = false;
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;
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
            isWorking = true;
            Task.Run(()=>CreateCarts(10, CustomerSpeed));

            var cashDesksTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c, CashDeskSpeed)));
            foreach (var task in cashDesksTasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            isWorking = false;
        }

        private void CashDeskWork(CashDesk cashDesk, int sleep)
        {
            while (isWorking)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Duqueue();
                    Thread.Sleep(sleep);
                }
            }
        }
        private void CreateCarts(int customerCounts, int sleep)
        {
            while (isWorking)
            {
                var customers = Generator.GetCustomers(customerCounts);
               

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var product in Generator.GetRandomProducts(10, 30))
                    {
                        cart.Add(product);
                    }
                    var cash = CashDesks[random.Next(CashDesks.Count)]; //TODO:
                    cash.Enqueue(cart);
                }

                Thread.Sleep(sleep);
            }
        }
    }
}
