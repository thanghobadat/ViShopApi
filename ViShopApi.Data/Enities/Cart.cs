using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViShopApi.Data.Enities
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool Status { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Order Order { get; set; }
    }
}
