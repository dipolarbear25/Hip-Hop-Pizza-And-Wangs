using Microsoft.EntityFrameworkCore;
using HHPW.Data;
using HHPW.Models;

namespace HHPW
{
    public class HipHopPizzaAndWangsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public HipHopPizzaAndWangsDbContext(DbContextOptions<HipHopPizzaAndWangsDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Item>().HasData(ItemData.Items);
            modelBuilder.Entity<Order>().HasData(OrderData.Orders);
        }
    }
}