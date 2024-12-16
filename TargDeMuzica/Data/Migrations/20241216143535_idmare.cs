using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Data.Migrations
{
    /// <inheritdoc />
    public partial class idmare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "ReviewID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewID",
                table: "Reviews",
                newName: "ReviewId");
        }
    }
}
