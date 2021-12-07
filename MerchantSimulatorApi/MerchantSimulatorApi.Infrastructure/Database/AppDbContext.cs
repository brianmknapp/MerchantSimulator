using MerchantSimulatorApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;


namespace MerchantSimulatorApi.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ShopItem> ShopItems { get; set; }
    }
}
