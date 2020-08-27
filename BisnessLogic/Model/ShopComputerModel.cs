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
        private CancellationTokenSource cancellationTokenSource;
        CancellationToken token;
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        private List<Task> tasks = new List<Task>();

        

        public ShopComputerModel()
        {
            var freeSellers = Generator.GetSellers(20);
            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;
            Generator.GetProducts(1000);
            Generator.GetCustomers(100);
            foreach (var seller in freeSellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue(), null));
            }
        }

        public void Start()
        {
            tasks.Add(new Task(()=>CreateCarts(10, token)));

            tasks.AddRange(CashDesks.Select(c=>new Task(()=> CashDeskWork(c, token))));
            foreach (var task in tasks)
            {
                task.Start();
            }
            
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        private void CashDeskWork(CashDesk cashDesk, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Duqueue();
                    Thread.Sleep(CashDeskSpeed);
                }
            }
        }
        private void CreateCarts(int customerCounts, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
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

                Thread.Sleep(CustomerSpeed);
            }
        }
    }
}
