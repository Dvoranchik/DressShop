using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Model
{ 
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Check> Cheks { get; set; }

        
        public override string ToString()
        {
            return Name;
        }
    }
}
