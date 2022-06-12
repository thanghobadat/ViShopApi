using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViShopApi.Data.Enities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime DateCreated { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LogoutTime { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
