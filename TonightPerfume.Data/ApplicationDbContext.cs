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
        public DbSet<Category> Categories { get; set; }
        public DbSet<PerfumeNote> PerfumeNotes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AromaGroup> AromaGroups { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Price> Prices { get; set; }

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
                builder.HasMany(x => x.PerfumeNotes)
                       .WithMany(x => x.Products)
                       .UsingEntity("ProductNotes");
                builder.HasMany(x => x.AromaGroups)
                       .WithMany(x => x.Products)
                       .UsingEntity("ProductAromaGroups");
                builder.HasOne(x => x.Category)
                       .WithMany(x => x.Products)
                       .HasForeignKey(x => x.Category_ID);
            });

            modelBuilder.Entity<RefreshToken>(builder =>
            {
                builder.ToTable("Tokens").HasKey(x => x.Token);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Categories").HasKey(x => x.Category_ID);
                builder.Property(x => x.Category_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PerfumeNote>(builder =>
            {
                builder.ToTable("PerfumeNotes").HasKey(x => x.Note_ID);
                builder.Property(x => x.Note_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Brand>(builder =>
            {
                builder.ToTable("Brands").HasKey(x => x.Brand_ID);
                builder.Property(x => x.Brand_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AromaGroup>(builder =>
            {
                builder.ToTable("AromaGroups").HasKey(x => x.AromaGroup_ID);
                builder.Property(x => x.AromaGroup_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Discount>(builder =>
            {
                builder.ToTable("Discounts").HasKey(x => x.Discount_ID);
                builder.Property(x => x.Discount_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Volume>(builder =>
            {
                builder.ToTable("Volumes").HasKey(x => x.Volume_ID);
                builder.Property(x => x.Volume_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Price>(builder =>
            {
                builder.ToTable("Prices").HasKey(x => x.Price_ID);
                builder.Property(x => x.Price_ID).ValueGeneratedOnAdd();
            });
        }
    }
}
