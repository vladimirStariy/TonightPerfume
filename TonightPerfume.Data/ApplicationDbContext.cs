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
                builder.HasData(
                    new Product[]
                    {
                        new Product {Product_ID = 1, Name = "Product #1", Category_ID = 1, Brand_ID = 1, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 2, Name = "Product #2", Category_ID = 1, Brand_ID = 2, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 3, Name = "Product #3", Category_ID = 1, Brand_ID = 3, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 4, Name = "Product #4", Category_ID = 1, Brand_ID = 1, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 5, Name = "Product #5", Category_ID = 1, Brand_ID = 2, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 6, Name = "Product #6", Category_ID = 1, Brand_ID = 3, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 7, Name = "Product #7", Category_ID = 1, Brand_ID = 1, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 8, Name = "Product #8", Category_ID = 1, Brand_ID = 2, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 9, Name = "Product #9", Category_ID = 1, Brand_ID = 3, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 10, Name = "Product #10", Category_ID = 1, Brand_ID = 1, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 11, Name = "Product #11", Category_ID = 1, Brand_ID = 2, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 12, Name = "Product #12", Category_ID = 1, Brand_ID = 3, Country="Италия", Year="2010", Description="Описание"},

                        new Product {Product_ID = 13, Name = "Product #13", Category_ID = 2, Brand_ID = 4, Country="Оман", Year="2010", Description="Описание"},
                        new Product {Product_ID = 14, Name = "Product #14", Category_ID = 2, Brand_ID = 5, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 15, Name = "Product #15", Category_ID = 2, Brand_ID = 6, Country="Испания", Year="2010", Description="Описание"},
                        new Product {Product_ID = 16, Name = "Product #16", Category_ID = 2, Brand_ID = 4, Country="Оман", Year="2010", Description="Описание"},
                        new Product {Product_ID = 17, Name = "Product #17", Category_ID = 2, Brand_ID = 5, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 18, Name = "Product #18", Category_ID = 2, Brand_ID = 6, Country="Испания", Year="2010", Description="Описание"},
                        new Product {Product_ID = 19, Name = "Product #19", Category_ID = 2, Brand_ID = 4, Country="Оман", Year="2010", Description="Описание"},
                        new Product {Product_ID = 20, Name = "Product #20", Category_ID = 2, Brand_ID = 5, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 21, Name = "Product #21", Category_ID = 2, Brand_ID = 6, Country="Испания", Year="2010", Description="Описание"},
                        new Product {Product_ID = 22, Name = "Product #22", Category_ID = 2, Brand_ID = 4, Country="Оман", Year="2010", Description="Описание"},
                        new Product {Product_ID = 23, Name = "Product #23", Category_ID = 2, Brand_ID = 5, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 24, Name = "Product #24", Category_ID = 2, Brand_ID = 6, Country="Испания", Year="2010", Description="Описание"},

                        new Product {Product_ID = 25, Name = "Product #25", Category_ID = 3, Brand_ID = 7, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 26, Name = "Product #26", Category_ID = 3, Brand_ID = 8, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 27, Name = "Product #27", Category_ID = 3, Brand_ID = 9, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 28, Name = "Product #28", Category_ID = 3, Brand_ID = 7, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 29, Name = "Product #29", Category_ID = 3, Brand_ID = 8, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 30, Name = "Product #30", Category_ID = 3, Brand_ID = 9, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 31, Name = "Product #31", Category_ID = 3, Brand_ID = 7, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 32, Name = "Product #32", Category_ID = 3, Brand_ID = 8, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 33, Name = "Product #33", Category_ID = 3, Brand_ID = 9, Country="ОАЭ", Year="2010", Description="Описание"},
                        new Product {Product_ID = 34, Name = "Product #34", Category_ID = 3, Brand_ID = 7, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 35, Name = "Product #35", Category_ID = 3, Brand_ID = 8, Country="США", Year="2010", Description="Описание"},
                        new Product {Product_ID = 36, Name = "Product #36", Category_ID = 3, Brand_ID = 9, Country="ОАЭ", Year="2010", Description="Описание"},

                        new Product {Product_ID = 37, Name = "Product #37", Category_ID = 4, Brand_ID = 10, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 38, Name = "Product #38", Category_ID = 4, Brand_ID = 11, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 39, Name = "Product #39", Category_ID = 4, Brand_ID = 12, Country="Испания", Year="2010", Description="Описание"},
                        new Product {Product_ID = 40, Name = "Product #40", Category_ID = 4, Brand_ID = 10, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 41, Name = "Product #41", Category_ID = 4, Brand_ID = 11, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 42, Name = "Product #42", Category_ID = 4, Brand_ID = 12, Country="Испания", Year="2010", Description="Описание"},
                        new Product {Product_ID = 43, Name = "Product #43", Category_ID = 4, Brand_ID = 10, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 44, Name = "Product #44", Category_ID = 4, Brand_ID = 11, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 45, Name = "Product #45", Category_ID = 4, Brand_ID = 12, Country="Испания", Year="2010", Description="Описание"},
                        new Product {Product_ID = 46, Name = "Product #46", Category_ID = 4, Brand_ID = 10, Country="Италия", Year="2010", Description="Описание"},
                        new Product {Product_ID = 47, Name = "Product #47", Category_ID = 4, Brand_ID = 11, Country="Франция", Year="2010", Description="Описание"},
                        new Product {Product_ID = 48, Name = "Product #48", Category_ID = 4, Brand_ID = 12, Country="Испания", Year="2010", Description="Описание"}
                    });
            });

            modelBuilder.Entity<RefreshToken>(builder =>
            {
                builder.ToTable("Tokens").HasKey(x => x.Token);
            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Categories").HasKey(x => x.Category_ID);
                builder.Property(x => x.Category_ID).ValueGeneratedOnAdd();
                builder.HasData(
                    new Category[]
                    {
                        new Category {Category_ID = 1, Name = "Для него"},
                        new Category {Category_ID = 2, Name = "Для неё"},
                        new Category {Category_ID = 3, Name = "Унисекс"},
                        new Category {Category_ID = 4, Name = "Аромабокс"}
                    });
            });

            modelBuilder.Entity<PerfumeNote>(builder =>
            {
                builder.ToTable("PerfumeNotes").HasKey(x => x.Note_ID);
                builder.Property(x => x.Note_ID).ValueGeneratedOnAdd();
                builder.HasData(
                    new PerfumeNote[]
                    {
                        new PerfumeNote {Note_ID = 1, Type = "upper", Name = "абрикос"},
                        new PerfumeNote {Note_ID = 2, Type = "upper", Name = "акваль"},
                        new PerfumeNote {Note_ID = 3, Type = "upper", Name = "акигалавуд"},
                        new PerfumeNote {Note_ID = 4, Type = "upper", Name = "альдегиды"},
                        new PerfumeNote {Note_ID = 5, Type = "upper", Name = "амбра"},
                        new PerfumeNote {Note_ID = 6, Type = "upper", Name = "амбретта"},
                        new PerfumeNote {Note_ID = 7, Type = "upper", Name = "амброксан"},
                        new PerfumeNote {Note_ID = 8, Type = "upper", Name = "ананас"},
                        new PerfumeNote {Note_ID = 9, Type = "upper", Name = "ангелика"},
                        new PerfumeNote {Note_ID = 10, Type = "upper", Name = "анис"},
                        new PerfumeNote {Note_ID = 11, Type = "middle", Name = "апельсин"},
                        new PerfumeNote {Note_ID = 12, Type = "middle", Name = "артемизия"},
                        new PerfumeNote {Note_ID = 13, Type = "middle", Name = "базилик"},
                        new PerfumeNote {Note_ID = 14, Type = "middle", Name = "бальзам"},
                        new PerfumeNote {Note_ID = 15, Type = "middle", Name = "бамбук"},
                        new PerfumeNote {Note_ID = 16, Type = "middle", Name = "бархатцы"},
                        new PerfumeNote {Note_ID = 17, Type = "middle", Name = "бензоин"},
                        new PerfumeNote {Note_ID = 18, Type = "middle", Name = "бергамот"},
                        new PerfumeNote {Note_ID = 19, Type = "middle", Name = "береза"},
                        new PerfumeNote {Note_ID = 20, Type = "middle", Name = "бобы тонка"},
                        new PerfumeNote {Note_ID = 21, Type = "bottom", Name = "боярышник"},
                        new PerfumeNote {Note_ID = 22, Type = "bottom", Name = "брусника"},
                        new PerfumeNote {Note_ID = 23, Type = "bottom", Name = "бучу"},
                        new PerfumeNote {Note_ID = 24, Type = "bottom", Name = "ваниль"},
                        new PerfumeNote {Note_ID = 25, Type = "bottom", Name = "вербена"},
                        new PerfumeNote {Note_ID = 26, Type = "bottom", Name = "ветивер"},
                        new PerfumeNote {Note_ID = 27, Type = "bottom", Name = "виниловый"},
                        new PerfumeNote {Note_ID = 28, Type = "bottom", Name = "вино"},
                        new PerfumeNote {Note_ID = 29, Type = "bottom", Name = "вишня"},
                        new PerfumeNote {Note_ID = 30, Type = "bottom", Name = "вода"}
                    });
            });

            modelBuilder.Entity<Brand>(builder =>
            {
                builder.ToTable("Brands").HasKey(x => x.Brand_ID);
                builder.Property(x => x.Brand_ID).ValueGeneratedOnAdd();
                builder.HasData(
                    new Brand[]
                    {
                        new Brand {Brand_ID = 1, Name = "Zarkoperfume"},
                        new Brand {Brand_ID = 2, Name = "Montale"},
                        new Brand {Brand_ID = 3, Name = "Kenzo"},
                        new Brand {Brand_ID = 4, Name = "Mancera"},
                        new Brand {Brand_ID = 5, Name = "Attar Collection"},
                        new Brand {Brand_ID = 6, Name = "Escentric Molecules"},
                        new Brand {Brand_ID = 7, Name = "Hermes"},
                        new Brand {Brand_ID = 8, Name = "Parfums de Marly"},
                        new Brand {Brand_ID = 9, Name = "YSL"},
                        new Brand {Brand_ID = 10, Name = "Tiziana Terenzi"},
                        new Brand {Brand_ID = 11, Name = "Jo Malone"},
                        new Brand {Brand_ID = 12, Name = "Byredo Parfums"},
                        new Brand {Brand_ID = 13, Name = "Acqua di Parma"},
                        new Brand {Brand_ID = 14, Name = "Thomas Kosmala"},
                        new Brand {Brand_ID = 15, Name = "Dior"},
                        new Brand {Brand_ID = 16, Name = "Nishane"},
                        new Brand {Brand_ID = 17, Name = "Sospiro"},
                        new Brand {Brand_ID = 18, Name = "Cartier"},
                        new Brand {Brand_ID = 19, Name = "EX Nihilo"},
                        new Brand {Brand_ID = 20, Name = "Tom Ford"}
                    });
            });

            modelBuilder.Entity<AromaGroup>(builder =>
            {
                builder.ToTable("AromaGroups").HasKey(x => x.AromaGroup_ID);
                builder.Property(x => x.AromaGroup_ID).ValueGeneratedOnAdd();
                builder.HasData(
                    new AromaGroup[]
                    {
                        new AromaGroup {AromaGroup_ID = 1, AromaGroup_Name = "акватические"},
                        new AromaGroup {AromaGroup_ID = 2, AromaGroup_Name = "альдегидные"},
                        new AromaGroup {AromaGroup_ID = 3, AromaGroup_Name = "ароматические"},
                        new AromaGroup {AromaGroup_ID = 4, AromaGroup_Name = "водяные"},
                        new AromaGroup {AromaGroup_ID = 5, AromaGroup_Name = "восточные"},
                        new AromaGroup {AromaGroup_ID = 6, AromaGroup_Name = "гурманские"},
                        new AromaGroup {AromaGroup_ID = 7, AromaGroup_Name = "древесные"},
                        new AromaGroup {AromaGroup_ID = 8, AromaGroup_Name = "зеленые"},
                        new AromaGroup {AromaGroup_ID = 9, AromaGroup_Name = "кожаные"},
                        new AromaGroup {AromaGroup_ID = 10, AromaGroup_Name = "мускусные"},
                        new AromaGroup {AromaGroup_ID = 11, AromaGroup_Name = "пряные"},
                        new AromaGroup {AromaGroup_ID = 12, AromaGroup_Name = "пудровые"},
                        new AromaGroup {AromaGroup_ID = 13, AromaGroup_Name = "свежие"},
                        new AromaGroup {AromaGroup_ID = 14, AromaGroup_Name = "табачные"},
                        new AromaGroup {AromaGroup_ID = 15, AromaGroup_Name = "фруктовые"},
                        new AromaGroup {AromaGroup_ID = 16, AromaGroup_Name = "фужерные"},
                        new AromaGroup {AromaGroup_ID = 17, AromaGroup_Name = "цветочные"},
                        new AromaGroup {AromaGroup_ID = 18, AromaGroup_Name = "цитрусовые"},
                        new AromaGroup {AromaGroup_ID = 19, AromaGroup_Name = "шипровые"},
                        new AromaGroup {AromaGroup_ID = 20, AromaGroup_Name = "экзотические"},
                    });
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
                builder.HasData(
                    new Volume[]
                    {
                        new Volume {Volume_ID = 1, Value = 2},
                        new Volume {Volume_ID = 2, Value = 5},
                        new Volume {Volume_ID = 3, Value = 8},
                        new Volume {Volume_ID = 4, Value = 10},
                        new Volume {Volume_ID = 5, Value = 15}
                    });
            });

            modelBuilder.Entity<Price>(builder =>
            {
                builder.ToTable("Prices").HasKey(x => x.Price_ID);
                builder.Property(x => x.Price_ID).ValueGeneratedOnAdd();
                builder.HasData(
                    new Price[]
                    {
                        new Price { Price_ID = 1, Product_ID = 1, Volume_ID = 1, Value=2235 },
                        new Price { Price_ID = 2, Product_ID = 1, Volume_ID = 2, Value=4335 },
                        new Price { Price_ID = 3, Product_ID = 1, Volume_ID = 3, Value=5435 },
                        new Price { Price_ID = 4, Product_ID = 1, Volume_ID = 4, Value=7635 },
                        new Price { Price_ID = 5, Product_ID = 1, Volume_ID = 5, Value=9735 },

                        new Price { Price_ID = 6, Product_ID = 2, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 7, Product_ID = 2, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 8, Product_ID = 2, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 9, Product_ID = 2, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 10, Product_ID = 2, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 11, Product_ID = 3, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 12, Product_ID = 3, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 13, Product_ID = 3, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 14, Product_ID = 3, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 15, Product_ID = 3, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 16, Product_ID = 4, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 17, Product_ID = 4, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 18, Product_ID = 4, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 19, Product_ID = 4, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 20, Product_ID = 4, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 21, Product_ID = 5, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 22, Product_ID = 5, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 23, Product_ID = 5, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 24, Product_ID = 5, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 25, Product_ID = 5, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 26, Product_ID = 6, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 27, Product_ID = 6, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 28, Product_ID = 6, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 29, Product_ID = 6, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 30, Product_ID = 6, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 31, Product_ID = 7, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 32, Product_ID = 7, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 33, Product_ID = 7, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 34, Product_ID = 7, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 35, Product_ID = 7, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 36, Product_ID = 8, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 37, Product_ID = 8, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 38, Product_ID = 8, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 39, Product_ID = 8, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 40, Product_ID = 8, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 41, Product_ID = 9, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 42, Product_ID = 9, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 43, Product_ID = 9, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 44, Product_ID = 9, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 45, Product_ID = 9, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 46, Product_ID = 10, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 47, Product_ID = 10, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 48, Product_ID = 10, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 49, Product_ID = 10, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 50, Product_ID = 10, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 51, Product_ID = 11, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 52, Product_ID = 11, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 53, Product_ID = 11, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 54, Product_ID = 11, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 55, Product_ID = 11, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 56, Product_ID = 12, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 57, Product_ID = 12, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 58, Product_ID = 12, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 59, Product_ID = 12, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 60, Product_ID = 12, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 61, Product_ID = 13, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 62, Product_ID = 13, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 63, Product_ID = 13, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 64, Product_ID = 13, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 65, Product_ID = 13, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 66, Product_ID = 14, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 67, Product_ID = 14, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 68, Product_ID = 14, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 69, Product_ID = 14, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 70, Product_ID = 14, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 71, Product_ID = 15, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 72, Product_ID = 15, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 73, Product_ID = 15, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 74, Product_ID = 15, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 75, Product_ID = 15, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 76, Product_ID = 16, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 77, Product_ID = 16, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 78, Product_ID = 16, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 79, Product_ID = 16, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 80, Product_ID = 16, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 81, Product_ID = 17, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 82, Product_ID = 17, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 83, Product_ID = 17, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 84, Product_ID = 17, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 85, Product_ID = 17, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 86, Product_ID = 18, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 87, Product_ID = 18, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 88, Product_ID = 18, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 89, Product_ID = 18, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 90, Product_ID = 18, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 91, Product_ID = 19, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 92, Product_ID = 19, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 93, Product_ID = 19, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 94, Product_ID = 19, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 95, Product_ID = 19, Volume_ID = 5, Value=8735 },

                        new Price { Price_ID = 96, Product_ID = 20, Volume_ID = 1, Value=2135 },
                        new Price { Price_ID = 97, Product_ID = 20, Volume_ID = 2, Value=4235 },
                        new Price { Price_ID = 98, Product_ID = 20, Volume_ID = 3, Value=4735 },
                        new Price { Price_ID = 99, Product_ID = 20, Volume_ID = 4, Value=6635 },
                        new Price { Price_ID = 100, Product_ID = 20, Volume_ID = 5, Value=8735 },
                    });
            });
        }
    }
}
