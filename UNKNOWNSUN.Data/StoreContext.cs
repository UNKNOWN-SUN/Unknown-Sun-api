using Unknown_Sun_Domain.Catalog;
using Unknown_Sun_Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace UNKOWNSUN.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Item>()
                .HasMany(item => item.Ratings)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            DbInitializer.Initialize(builder);
        }
    }
}