using Microsoft.EntityFrameworkCore;
using MVCEcommerce.Models.Entities;

namespace MVCEcommerce.Data
{
    public class ProductDbContext :DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>options):base(options) 
        {
            
        }
        public DbSet<ProductDetail> productDetail { get; set; }
        public DbSet<ProductCategory> productCategory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetail>()
                .Ignore(p => p.File); 
        }

    }
}
