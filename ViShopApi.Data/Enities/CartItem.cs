using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViShopApi.Data.Enities
{
    public class CartItem
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int CartId { get; set; }
        public Order Cart { get; set; }
    }
}
