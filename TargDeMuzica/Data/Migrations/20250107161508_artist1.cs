using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Data.Migrations
{
    /// <inheritdoc />
    public partial class artist1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Artists_ArtistID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Artists_ArtistID",
                table: "Products",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Artists_ArtistID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Artists_ArtistID",
                table: "Products",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
