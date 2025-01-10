using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TargDeMuzica.Data.Migrations
{
    /// <inheritdoc />
    public partial class increq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomingRequests_Products_ProductID",
                table: "IncomingRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_IncomingRequests_IncomingRequestRequestID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IncomingRequestRequestID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_IncomingRequests_ProductID",
                table: "IncomingRequests");

            migrationBuilder.DropColumn(
                name: "IncomingRequestRequestID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequestApproved",
                table: "IncomingRequests");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "IncomingRequests",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "IncomingRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposedProductProductID",
                table: "IncomingRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "IncomingRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_IncomingRequests_ProposedProductProductID",
                table: "IncomingRequests",
                column: "ProposedProductProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomingRequests_Products_ProposedProductProductID",
                table: "IncomingRequests",
                column: "ProposedProductProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomingRequests_Products_ProposedProductProductID",
                table: "IncomingRequests");

            migrationBuilder.DropIndex(
                name: "IX_IncomingRequests_ProposedProductProductID",
                table: "IncomingRequests");

            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "IncomingRequests");

            migrationBuilder.DropColumn(
                name: "ProposedProductProductID",
                table: "IncomingRequests");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "IncomingRequests");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "IncomingRequests",
                newName: "ProductID");

            migrationBuilder.AddColumn<int>(
                name: "IncomingRequestRequestID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequestApproved",
                table: "IncomingRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IncomingRequestRequestID",
                table: "Products",
                column: "IncomingRequestRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingRequests_ProductID",
                table: "IncomingRequests",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomingRequests_Products_ProductID",
                table: "IncomingRequests",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_IncomingRequests_IncomingRequestRequestID",
                table: "Products",
                column: "IncomingRequestRequestID",
                principalTable: "IncomingRequests",
                principalColumn: "RequestID");
        }
    }
}
