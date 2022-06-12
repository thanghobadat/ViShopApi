using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViShopApi.Data.EF
{
    public class ViShopDbContextFactory : IDesignTimeDbContextFactory<ViShopDbContext>
    {
        public ViShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ViShop");

            var optionsBuilder = new DbContextOptionsBuilder<ViShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ViShopDbContext(optionsBuilder.Options);
        }
    }
}
