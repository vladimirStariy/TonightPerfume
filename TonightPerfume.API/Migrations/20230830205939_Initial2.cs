using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TonightPerfume.API.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AromaGroups",
                columns: table => new
                {
                    AromaGroup_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AromaGroup_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AromaGroups", x => x.AromaGroup_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductAromaGroups",
                columns: table => new
                {
                    AromaGroupsAromaGroup_ID = table.Column<uint>(type: "int unsigned", nullable: false),
                    ProductsProduct_ID = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAromaGroups", x => new { x.AromaGroupsAromaGroup_ID, x.ProductsProduct_ID });
                    table.ForeignKey(
                        name: "FK_ProductAromaGroups_AromaGroups_AromaGroupsAromaGroup_ID",
                        column: x => x.AromaGroupsAromaGroup_ID,
                        principalTable: "AromaGroups",
                        principalColumn: "AromaGroup_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAromaGroups_Products_ProductsProduct_ID",
                        column: x => x.ProductsProduct_ID,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAromaGroups_ProductsProduct_ID",
                table: "ProductAromaGroups",
                column: "ProductsProduct_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAromaGroups");

            migrationBuilder.DropTable(
                name: "AromaGroups");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Products");
        }
    }
}
