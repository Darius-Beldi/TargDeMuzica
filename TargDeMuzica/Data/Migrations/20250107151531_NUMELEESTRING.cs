using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Data.Migrations
{
    /// <inheritdoc />
    public partial class NUMELEESTRING : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MusicSuportName",
                table: "MusicSuports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MusicSuportName",
                table: "MusicSuports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
