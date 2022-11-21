using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Qty { get; set; }
        public double ExtPrice { get; set; }

        public OrderLine(Product product, int qty)
        {
            this.Product = product;
            this.Qty = qty;
            ExtPrice = (double)qty * product.Price;
        }
    }
}
