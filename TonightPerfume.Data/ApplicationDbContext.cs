using Microsoft.EntityFrameworkCore;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<BaseUser> Users { get; set; }
        public DbSet<RefreshToken> Tokens { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseUser>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.User_ID);
                builder.Property(x => x.User_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Products").HasKey(x => x.Product_ID);
                builder.Property(x => x.Product_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RefreshToken>(builder =>
            {
                builder.ToTable("Tokens").HasKey(x => x.Token);
            });
        }
    }
}
