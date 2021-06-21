using Microsoft.EntityFrameworkCore;

namespace ProductReviewAuthentication.Models
{
    public class ProductAuthenticationDbContext : DbContext
    {
        public ProductAuthenticationDbContext(DbContextOptions<ProductAuthenticationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Product)
                .WithOne(u => u.User);

            modelBuilder.Entity<Product>()
               .HasMany(p => p.Review)
               .WithOne(p => p.Product);

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
