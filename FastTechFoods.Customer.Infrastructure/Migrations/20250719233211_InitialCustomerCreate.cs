using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastTechFoods.Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCustomerCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Category = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CustomerId = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    DeliveryMethod = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    CancellationReason = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    MenuItemId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    OrderId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
