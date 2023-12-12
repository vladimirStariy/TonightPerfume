using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonightPerfume.API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductNotes_PermumeNotes_PerfumeNotesNote_ID",
                table: "ProductNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermumeNotes",
                table: "PermumeNotes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "PermumeNotes",
                newName: "PerfumeNotes");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Brands",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfumeNotes",
                table: "PerfumeNotes",
                column: "Note_ID");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Discount_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Discount_Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand_ID = table.Column<uint>(type: "int unsigned", nullable: true),
                    User_ID = table.Column<uint>(type: "int unsigned", nullable: true),
                    Product_ID = table.Column<uint>(type: "int unsigned", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Discount_ID);
                    table.ForeignKey(
                        name: "FK_Discounts_Brands_Brand_ID",
                        column: x => x.Brand_ID,
                        principalTable: "Brands",
                        principalColumn: "Brand_ID");
                    table.ForeignKey(
                        name: "FK_Discounts_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "Product_ID");
                    table.ForeignKey(
                        name: "FK_Discounts_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<uint>(type: "int unsigned", nullable: false),
                    Product_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Order_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isNew = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Appartaments = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DomophoneCode = table.Column<int>(type: "int", nullable: true),
                    Entrance = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    PostNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Promocode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SummaryPrice = table.Column<int>(type: "int", nullable: true),
                    isCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isCanceled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrderCompleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    User_ID = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Profile_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Middlename = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isFilled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    User_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Profile_ID);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Promocode_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PromocodeBody = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsingQuantity = table.Column<int>(type: "int", nullable: false),
                    Circulation = table.Column<int>(type: "int", nullable: false),
                    isExpired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Promocode_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Volumes",
                columns: table => new
                {
                    Volume_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumes", x => x.Volume_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Adress_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Appartaments = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DomophoneCode = table.Column<int>(type: "int", nullable: true),
                    Entrance = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    PostNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryType = table.Column<int>(type: "int", nullable: false),
                    Profile_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Adress_ID);
                    table.ForeignKey(
                        name: "FK_Adresses_Profiles_Profile_ID",
                        column: x => x.Profile_ID,
                        principalTable: "Profiles",
                        principalColumn: "Profile_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AtomizerColors",
                columns: table => new
                {
                    AtomizerColor_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Volume_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtomizerColors", x => x.AtomizerColor_ID);
                    table.ForeignKey(
                        name: "FK_AtomizerColors_Volumes_Volume_ID",
                        column: x => x.Volume_ID,
                        principalTable: "Volumes",
                        principalColumn: "Volume_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Price_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Product_ID = table.Column<uint>(type: "int unsigned", nullable: false),
                    Volume_ID = table.Column<uint>(type: "int unsigned", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    PriceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isActual = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Price_ID);
                    table.ForeignKey(
                        name: "FK_Prices_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prices_Volumes_Volume_ID",
                        column: x => x.Volume_ID,
                        principalTable: "Volumes",
                        principalColumn: "Volume_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProduct_Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Order_ID = table.Column<uint>(type: "int unsigned", nullable: false),
                    Price_ID = table.Column<uint>(type: "int unsigned", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProduct_Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Prices_Price_ID",
                        column: x => x.Price_ID,
                        principalTable: "Prices",
                        principalColumn: "Price_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AromaGroups",
                columns: new[] { "AromaGroup_ID", "AromaGroup_Name" },
                values: new object[,]
                {
                    { 1u, "акватические" },
                    { 2u, "альдегидные" },
                    { 3u, "ароматические" },
                    { 4u, "водяные" },
                    { 5u, "восточные" },
                    { 6u, "гурманские" },
                    { 7u, "древесные" },
                    { 8u, "зеленые" },
                    { 9u, "кожаные" },
                    { 10u, "мускусные" },
                    { 11u, "пряные" },
                    { 12u, "пудровые" },
                    { 13u, "свежие" },
                    { 14u, "табачные" },
                    { 15u, "фруктовые" },
                    { 16u, "фужерные" },
                    { 17u, "цветочные" },
                    { 18u, "цитрусовые" },
                    { 19u, "шипровые" },
                    { 20u, "экзотические" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Brand_ID", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1u, null, "Zarkoperfume" },
                    { 2u, null, "Montale" },
                    { 3u, null, "Kenzo" },
                    { 4u, null, "Mancera" },
                    { 5u, null, "Attar Collection" },
                    { 6u, null, "Escentric Molecules" },
                    { 7u, null, "Hermes" },
                    { 8u, null, "Parfums de Marly" },
                    { 9u, null, "YSL" },
                    { 10u, null, "Tiziana Terenzi" },
                    { 11u, null, "Jo Malone" },
                    { 12u, null, "Byredo Parfums" },
                    { 13u, null, "Acqua di Parma" },
                    { 14u, null, "Thomas Kosmala" },
                    { 15u, null, "Dior" },
                    { 16u, null, "Nishane" },
                    { 17u, null, "Sospiro" },
                    { 18u, null, "Cartier" },
                    { 19u, null, "EX Nihilo" },
                    { 20u, null, "Tom Ford" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Category_ID", "Name" },
                values: new object[,]
                {
                    { 1u, "Для него" },
                    { 2u, "Для неё" },
                    { 3u, "Унисекс" },
                    { 4u, "Аромабокс" }
                });

            migrationBuilder.InsertData(
                table: "PerfumeNotes",
                columns: new[] { "Note_ID", "Name", "Type" },
                values: new object[,]
                {
                    { 1u, "абрикос", "upper" },
                    { 2u, "акваль", "upper" },
                    { 3u, "акигалавуд", "upper" },
                    { 4u, "альдегиды", "upper" },
                    { 5u, "амбра", "upper" },
                    { 6u, "амбретта", "upper" },
                    { 7u, "амброксан", "upper" },
                    { 8u, "ананас", "upper" },
                    { 9u, "ангелика", "upper" },
                    { 10u, "анис", "upper" },
                    { 11u, "апельсин", "middle" },
                    { 12u, "артемизия", "middle" },
                    { 13u, "базилик", "middle" },
                    { 14u, "бальзам", "middle" },
                    { 15u, "бамбук", "middle" },
                    { 16u, "бархатцы", "middle" },
                    { 17u, "бензоин", "middle" },
                    { 18u, "бергамот", "middle" },
                    { 19u, "береза", "middle" },
                    { 20u, "бобы тонка", "middle" },
                    { 21u, "боярышник", "bottom" },
                    { 22u, "брусника", "bottom" },
                    { 23u, "бучу", "bottom" },
                    { 24u, "ваниль", "bottom" },
                    { 25u, "вербена", "bottom" },
                    { 26u, "ветивер", "bottom" },
                    { 27u, "виниловый", "bottom" },
                    { 28u, "вино", "bottom" },
                    { 29u, "вишня", "bottom" },
                    { 30u, "вода", "bottom" }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Promocode_ID", "Circulation", "ExpirationDate", "PromocodeBody", "UsingQuantity", "Value", "isExpired" },
                values: new object[] { 1u, 300, new DateTime(2024, 1, 5, 7, 37, 0, 951, DateTimeKind.Utc).AddTicks(45), "TEST_PROMOCODE", 99999, "10", false });

            migrationBuilder.InsertData(
                table: "Volumes",
                columns: new[] { "Volume_ID", "Value" },
                values: new object[,]
                {
                    { 1u, 2 },
                    { 2u, 5 },
                    { 3u, 8 },
                    { 4u, 10 },
                    { 5u, 15 }
                });

            migrationBuilder.InsertData(
                table: "AtomizerColors",
                columns: new[] { "AtomizerColor_ID", "Color", "Volume_ID" },
                values: new object[,]
                {
                    { 1u, "black", 1u },
                    { 2u, "pink", 1u },
                    { 3u, "gold", 1u },
                    { 4u, "blue", 1u },
                    { 5u, "red", 1u },
                    { 6u, "grey", 1u },
                    { 7u, "black", 2u },
                    { 8u, "pink", 2u },
                    { 9u, "gold", 2u },
                    { 10u, "blue", 2u },
                    { 11u, "red", 2u },
                    { 12u, "grey", 2u },
                    { 13u, "black", 3u },
                    { 14u, "pink", 3u },
                    { 15u, "gold", 3u },
                    { 16u, "blue", 3u },
                    { 17u, "red", 3u },
                    { 18u, "grey", 3u },
                    { 19u, "black", 4u },
                    { 20u, "pink", 4u },
                    { 21u, "gold", 4u },
                    { 22u, "blue", 4u },
                    { 23u, "red", 4u },
                    { 24u, "grey", 4u },
                    { 25u, "black", 5u },
                    { 26u, "pink", 5u },
                    { 27u, "gold", 5u },
                    { 28u, "blue", 5u },
                    { 29u, "red", 5u },
                    { 30u, "grey", 5u }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_ID", "Brand_ID", "Category_ID", "Country", "Description", "Name", "Year" },
                values: new object[,]
                {
                    { 1u, 1u, 1u, "США", "Описание", "Product #1", "2010" },
                    { 2u, 2u, 1u, "Франция", "Описание", "Product #2", "2010" },
                    { 3u, 3u, 1u, "Италия", "Описание", "Product #3", "2010" },
                    { 4u, 1u, 1u, "США", "Описание", "Product #4", "2010" },
                    { 5u, 2u, 1u, "Франция", "Описание", "Product #5", "2010" },
                    { 6u, 3u, 1u, "Италия", "Описание", "Product #6", "2010" },
                    { 7u, 1u, 1u, "США", "Описание", "Product #7", "2010" },
                    { 8u, 2u, 1u, "Франция", "Описание", "Product #8", "2010" },
                    { 9u, 3u, 1u, "Италия", "Описание", "Product #9", "2010" },
                    { 10u, 1u, 1u, "США", "Описание", "Product #10", "2010" },
                    { 11u, 2u, 1u, "Франция", "Описание", "Product #11", "2010" },
                    { 12u, 3u, 1u, "Италия", "Описание", "Product #12", "2010" },
                    { 13u, 4u, 2u, "Оман", "Описание", "Product #13", "2010" },
                    { 14u, 5u, 2u, "ОАЭ", "Описание", "Product #14", "2010" },
                    { 15u, 6u, 2u, "Испания", "Описание", "Product #15", "2010" },
                    { 16u, 4u, 2u, "Оман", "Описание", "Product #16", "2010" },
                    { 17u, 5u, 2u, "ОАЭ", "Описание", "Product #17", "2010" },
                    { 18u, 6u, 2u, "Испания", "Описание", "Product #18", "2010" },
                    { 19u, 4u, 2u, "Оман", "Описание", "Product #19", "2010" },
                    { 20u, 5u, 2u, "ОАЭ", "Описание", "Product #20", "2010" },
                    { 21u, 6u, 2u, "Испания", "Описание", "Product #21", "2010" },
                    { 22u, 4u, 2u, "Оман", "Описание", "Product #22", "2010" },
                    { 23u, 5u, 2u, "ОАЭ", "Описание", "Product #23", "2010" },
                    { 24u, 6u, 2u, "Испания", "Описание", "Product #24", "2010" },
                    { 25u, 7u, 3u, "Франция", "Описание", "Product #25", "2010" },
                    { 26u, 8u, 3u, "США", "Описание", "Product #26", "2010" },
                    { 27u, 9u, 3u, "ОАЭ", "Описание", "Product #27", "2010" },
                    { 28u, 7u, 3u, "Франция", "Описание", "Product #28", "2010" },
                    { 29u, 8u, 3u, "США", "Описание", "Product #29", "2010" },
                    { 30u, 9u, 3u, "ОАЭ", "Описание", "Product #30", "2010" },
                    { 31u, 7u, 3u, "Франция", "Описание", "Product #31", "2010" },
                    { 32u, 8u, 3u, "США", "Описание", "Product #32", "2010" },
                    { 33u, 9u, 3u, "ОАЭ", "Описание", "Product #33", "2010" },
                    { 34u, 7u, 3u, "Франция", "Описание", "Product #34", "2010" },
                    { 35u, 8u, 3u, "США", "Описание", "Product #35", "2010" },
                    { 36u, 9u, 3u, "ОАЭ", "Описание", "Product #36", "2010" },
                    { 37u, 10u, 4u, "Италия", "Описание", "Product #37", "2010" },
                    { 38u, 11u, 4u, "Франция", "Описание", "Product #38", "2010" },
                    { 39u, 12u, 4u, "Испания", "Описание", "Product #39", "2010" },
                    { 40u, 10u, 4u, "Италия", "Описание", "Product #40", "2010" },
                    { 41u, 11u, 4u, "Франция", "Описание", "Product #41", "2010" },
                    { 42u, 12u, 4u, "Испания", "Описание", "Product #42", "2010" },
                    { 43u, 10u, 4u, "Италия", "Описание", "Product #43", "2010" },
                    { 44u, 11u, 4u, "Франция", "Описание", "Product #44", "2010" },
                    { 45u, 12u, 4u, "Испания", "Описание", "Product #45", "2010" },
                    { 46u, 10u, 4u, "Италия", "Описание", "Product #46", "2010" },
                    { 47u, 11u, 4u, "Франция", "Описание", "Product #47", "2010" },
                    { 48u, 12u, 4u, "Испания", "Описание", "Product #48", "2010" }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Price_ID", "PriceDate", "Product_ID", "Value", "Volume_ID", "isActual" },
                values: new object[,]
                {
                    { 1u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6308), 1u, 2235, 1u, true },
                    { 2u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6318), 1u, 4335, 2u, true },
                    { 3u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6319), 1u, 5435, 3u, true },
                    { 4u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6320), 1u, 7635, 4u, true },
                    { 5u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6321), 1u, 9735, 5u, true },
                    { 6u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6323), 2u, 2135, 1u, true },
                    { 7u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6323), 2u, 4235, 2u, true },
                    { 8u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6324), 2u, 4735, 3u, true },
                    { 9u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6325), 2u, 6635, 4u, true },
                    { 10u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6326), 2u, 8735, 5u, true },
                    { 11u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6326), 3u, 2135, 1u, true },
                    { 12u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6327), 3u, 4235, 2u, true },
                    { 13u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6328), 3u, 4735, 3u, true },
                    { 14u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6329), 3u, 6635, 4u, true },
                    { 15u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6330), 3u, 8735, 5u, true },
                    { 16u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6331), 4u, 2135, 1u, true },
                    { 17u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6332), 4u, 4235, 2u, true },
                    { 18u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6332), 4u, 4735, 3u, true },
                    { 19u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6333), 4u, 6635, 4u, true },
                    { 20u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6336), 4u, 8735, 5u, true },
                    { 21u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6337), 5u, 2135, 1u, true },
                    { 22u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6338), 5u, 4235, 2u, true },
                    { 23u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6339), 5u, 4735, 3u, true },
                    { 24u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6339), 5u, 6635, 4u, true },
                    { 25u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6340), 5u, 8735, 5u, true },
                    { 26u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6341), 6u, 2135, 1u, true },
                    { 27u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6342), 6u, 4235, 2u, true },
                    { 28u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6342), 6u, 4735, 3u, true },
                    { 29u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6343), 6u, 6635, 4u, true },
                    { 30u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6344), 6u, 8735, 5u, true },
                    { 31u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6344), 7u, 2135, 1u, true },
                    { 32u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6345), 7u, 4235, 2u, true },
                    { 33u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6346), 7u, 4735, 3u, true },
                    { 34u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6347), 7u, 6635, 4u, true },
                    { 35u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6347), 7u, 8735, 5u, true },
                    { 36u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6349), 8u, 2135, 1u, true },
                    { 37u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6349), 8u, 4235, 2u, true },
                    { 38u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6350), 8u, 4735, 3u, true },
                    { 39u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6351), 8u, 6635, 4u, true },
                    { 40u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6393), 8u, 8735, 5u, true },
                    { 41u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6394), 9u, 2135, 1u, true },
                    { 42u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6394), 9u, 4235, 2u, true },
                    { 43u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6395), 9u, 4735, 3u, true },
                    { 44u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6396), 9u, 6635, 4u, true },
                    { 45u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6397), 9u, 8735, 5u, true },
                    { 46u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6397), 10u, 2135, 1u, true },
                    { 47u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6398), 10u, 4235, 2u, true },
                    { 48u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6399), 10u, 4735, 3u, true },
                    { 49u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6400), 10u, 6635, 4u, true },
                    { 50u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6400), 10u, 8735, 5u, true },
                    { 51u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6401), 11u, 2135, 1u, true },
                    { 52u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6402), 11u, 4235, 2u, true },
                    { 53u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6403), 11u, 4735, 3u, true },
                    { 54u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6403), 11u, 6635, 4u, true },
                    { 55u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6404), 11u, 8735, 5u, true },
                    { 56u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6405), 12u, 2135, 1u, true },
                    { 57u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6406), 12u, 4235, 2u, true },
                    { 58u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6407), 12u, 4735, 3u, true },
                    { 59u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6408), 12u, 6635, 4u, true },
                    { 60u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6408), 12u, 8735, 5u, true },
                    { 61u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6409), 13u, 2135, 1u, true },
                    { 62u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6410), 13u, 4235, 2u, true },
                    { 63u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6411), 13u, 4735, 3u, true },
                    { 64u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6414), 13u, 6635, 4u, true },
                    { 65u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6415), 13u, 8735, 5u, true },
                    { 66u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6415), 14u, 2135, 1u, true },
                    { 67u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6416), 14u, 4235, 2u, true },
                    { 68u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6417), 14u, 4735, 3u, true },
                    { 69u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6418), 14u, 6635, 4u, true },
                    { 70u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6419), 14u, 8735, 5u, true },
                    { 71u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6420), 15u, 2135, 1u, true },
                    { 72u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6420), 15u, 4235, 2u, true },
                    { 73u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6421), 15u, 4735, 3u, true },
                    { 74u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6422), 15u, 6635, 4u, true },
                    { 75u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6422), 15u, 8735, 5u, true },
                    { 76u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6423), 16u, 2135, 1u, true },
                    { 77u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6424), 16u, 4235, 2u, true },
                    { 78u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6425), 16u, 4735, 3u, true },
                    { 79u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6426), 16u, 6635, 4u, true },
                    { 80u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6427), 16u, 8735, 5u, true },
                    { 81u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6427), 17u, 2135, 1u, true },
                    { 82u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6428), 17u, 4235, 2u, true },
                    { 83u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6429), 17u, 4735, 3u, true },
                    { 84u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6429), 17u, 6635, 4u, true },
                    { 85u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6430), 17u, 8735, 5u, true },
                    { 86u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6431), 18u, 2135, 1u, true },
                    { 87u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6432), 18u, 4235, 2u, true },
                    { 88u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6433), 18u, 4735, 3u, true },
                    { 89u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6434), 18u, 6635, 4u, true },
                    { 90u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6435), 18u, 8735, 5u, true },
                    { 91u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6435), 19u, 2135, 1u, true },
                    { 92u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6436), 19u, 4235, 2u, true },
                    { 93u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6437), 19u, 4735, 3u, true },
                    { 94u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6437), 19u, 6635, 4u, true },
                    { 95u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6438), 19u, 8735, 5u, true },
                    { 96u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6439), 20u, 2135, 1u, true },
                    { 97u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6440), 20u, 4235, 2u, true },
                    { 98u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6441), 20u, 4735, 3u, true },
                    { 99u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6441), 20u, 6635, 4u, true },
                    { 100u, new DateTime(2023, 12, 6, 10, 37, 0, 950, DateTimeKind.Local).AddTicks(6442), 20u, 8735, 5u, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_Profile_ID",
                table: "Adresses",
                column: "Profile_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AtomizerColors_Volume_ID",
                table: "AtomizerColors",
                column: "Volume_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Brand_ID",
                table: "Discounts",
                column: "Brand_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Product_ID",
                table: "Discounts",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_User_ID",
                table: "Discounts",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_Order_ID",
                table: "OrderProducts",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_Price_ID",
                table: "OrderProducts",
                column: "Price_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Product_ID",
                table: "Prices",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Volume_ID",
                table: "Prices",
                column: "Volume_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_User_ID",
                table: "Profiles",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductNotes_PerfumeNotes_PerfumeNotesNote_ID",
                table: "ProductNotes",
                column: "PerfumeNotesNote_ID",
                principalTable: "PerfumeNotes",
                principalColumn: "Note_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductNotes_PerfumeNotes_PerfumeNotesNote_ID",
                table: "ProductNotes");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "AtomizerColors");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Volumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfumeNotes",
                table: "PerfumeNotes");

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "AromaGroups",
                keyColumn: "AromaGroup_ID",
                keyValue: 20u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 20u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 20u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 21u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 22u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 23u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 24u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 25u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 26u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 27u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 28u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 29u);

            migrationBuilder.DeleteData(
                table: "PerfumeNotes",
                keyColumn: "Note_ID",
                keyValue: 30u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 21u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 22u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 23u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 24u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 25u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 26u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 27u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 28u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 29u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 30u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 31u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 32u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 33u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 34u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 35u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 36u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 37u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 38u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 39u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 40u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 41u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 42u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 43u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 44u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 45u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 46u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 47u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 48u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 20u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Brand_ID",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Category_ID",
                keyValue: 2u);

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "PerfumeNotes",
                newName: "PermumeNotes");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "ImagePath",
                keyValue: null,
                column: "ImagePath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Brands",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermumeNotes",
                table: "PermumeNotes",
                column: "Note_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductNotes_PermumeNotes_PerfumeNotesNote_ID",
                table: "ProductNotes",
                column: "PerfumeNotesNote_ID",
                principalTable: "PermumeNotes",
                principalColumn: "Note_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
