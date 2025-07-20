using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastTechFoods.Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToAlterCustomerIdToFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UNIQUEIDENTIFIER");
        }
    }
}
