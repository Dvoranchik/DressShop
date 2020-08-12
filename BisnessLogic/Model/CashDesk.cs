using System;
using System.Collections.Generic;

namespace BisnessLogic.Model
{
    public class CashDesk
    {
        Context db;
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int Number { get; set; }

        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }
        public int Count => Queue.Count;
        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        public decimal Duqueue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
                return 0;
            var cart = Queue.Dequeue();
            if (cart != null)
            {
                var check = new Check()
                {
                    SellerID = Seller.SellerId,
                    Seller = Seller,
                    Customer = cart.Customer,
                    CustomerID = cart.Customer.CustomerID,
                    CreatedTime = DateTime.Now
                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in cart)
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        product.Count--;
                        sells.Add(sell);

                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        sum += product.Price;
                    }
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                }
            }

            return sum;
        }

        
    }
}
