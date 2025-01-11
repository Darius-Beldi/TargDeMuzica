using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Migrations
{
    /// <inheritdoc />
    public partial class nucolectie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicSuportProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MusicSuportID",
                table: "Products",
                column: "MusicSuportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MusicSuports_MusicSuportID",
                table: "Products",
                column: "MusicSuportID",
                principalTable: "MusicSuports",
                principalColumn: "MusicSuportID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MusicSuports_MusicSuportID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MusicSuportID",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "MusicSuportProduct",
                columns: table => new
                {
                    MusicSuportID = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicSuportProduct", x => new { x.MusicSuportID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_MusicSuportProduct_MusicSuports_MusicSuportID",
                        column: x => x.MusicSuportID,
                        principalTable: "MusicSuports",
                        principalColumn: "MusicSuportID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicSuportProduct_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicSuportProduct_ProductsProductID",
                table: "MusicSuportProduct",
                column: "ProductsProductID");
        }
    }
}
