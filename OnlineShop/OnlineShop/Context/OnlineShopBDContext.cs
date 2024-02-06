using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Context
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<Item> Products { get; set; }

        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {
        }
    }
}
