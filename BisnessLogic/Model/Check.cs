using System;
using System.Collections.Generic;

namespace BisnessLogic.Model
{
    public class Check
    {
        public int CheckId { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; }
        public DateTime CreatedTime { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{CheckId} from " +
                   $"{CreatedTime.ToString("g")}";
        }
    }
}
