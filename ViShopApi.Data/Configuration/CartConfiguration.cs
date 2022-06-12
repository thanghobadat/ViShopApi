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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.ToTable("Carts");

            builder.HasOne(t => t.AppUser).WithMany(pc => pc.Carts)
                .HasForeignKey(pc => pc.UserId);

            builder.Property(x => x.Status).IsRequired();
        }
    }
}
