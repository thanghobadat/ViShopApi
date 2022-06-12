using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViShopApi.Data.Enities;

namespace ViShopApi.Data.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(t => t.Product).WithMany(pc => pc.CartItems)
                .HasForeignKey(pc => pc.ProductId);
            builder.HasOne(t => t.Cart).WithMany(pc => pc.CartItems)
                 .HasForeignKey(pc => pc.CartId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
