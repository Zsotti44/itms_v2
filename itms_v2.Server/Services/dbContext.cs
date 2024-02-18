using itms_v2.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace itms_v2.Server.Services
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { 
        
        }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<TruckDriver> TruckDrivers { get; set; }
        public DbSet<WorkTruck> Workers { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Workticket> Worktickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }
    }
}
