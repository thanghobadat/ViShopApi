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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.IsOnline).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Age).IsRequired();
        }
    }
}
