using System.Data.Entity;
using BREntityFramework.Models;

namespace BREntityFramework
{
    internal class ShopDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //public static DbContextOptions<ShopDBContext> Options = new DbContextOptions<ShopDBContext>

        public ShopDBContext() : base("Server=localhost;Database=ShopDB;Trusted_Connection=True")
        { 
        }

        /*
        protected override void Onconfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            optionsBuilder.LogTo(Console.WriteLine);
        }
        */
    }
}
