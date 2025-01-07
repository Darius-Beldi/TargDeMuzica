using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MusicSuports_MusicSuportID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MusicSuportID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "MusicSuportID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MusicSuportID",
                table: "Products",
                column: "MusicSuportID",
                unique: true,
                filter: "[MusicSuportID] IS NOT NULL");

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

            migrationBuilder.AlterColumn<int>(
                name: "MusicSuportID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MusicSuportID",
                table: "Products",
                column: "MusicSuportID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MusicSuports_MusicSuportID",
                table: "Products",
                column: "MusicSuportID",
                principalTable: "MusicSuports",
                principalColumn: "MusicSuportID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
