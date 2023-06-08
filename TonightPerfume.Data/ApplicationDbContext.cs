using Microsoft.EntityFrameworkCore;
using TonightPerfume.Domain.Models.Product;
using TonightPerfume.Domain.Models.User;

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
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseUser>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.User_ID);
                builder.Property(x => x.User_ID).ValueGeneratedOnAdd();

                builder.HasData(new BaseUser
                {
                    User_ID = 1,
                    Username = "User1",
                    Password = "User1"
                });
                builder.HasData(new BaseUser
                {
                    User_ID = 2,
                    Username = "User2",
                    Password = "User2"
                });
                builder.HasData(new BaseUser
                {
                    User_ID = 3,
                    Username = "User3",
                    Password = "User3"
                });
            });
            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Products").HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.HasData(new Product
                {
                    Id = 1,
                    Name = "Product1"
                });
                builder.HasData(new Product
                {
                    Id = 2,
                    Name = "Product2"
                });
                builder.HasData(new Product
                {
                    Id = 3,
                    Name = "Product3"
                });
            });
        }
    }
}
