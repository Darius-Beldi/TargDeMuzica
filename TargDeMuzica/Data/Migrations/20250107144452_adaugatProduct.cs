using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Data.Migrations
{
    /// <inheritdoc />
    public partial class adaugatProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageLocation",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "ProductPrice",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ProductScore",
                table: "Products",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageLocation",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductScore",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductStock",
                table: "Products");
        }
    }
}
