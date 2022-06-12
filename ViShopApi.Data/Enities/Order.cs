using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViShopApi.Data.Enities
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public double TotalPrice { get; set; }
    }
}
