using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShoppingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Baskets_BasketId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_BasketId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Baskets_Id",
                table: "orders",
                column: "Id",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Baskets_Id",
                table: "orders");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_orders_BasketId",
                table: "orders",
                column: "BasketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Baskets_BasketId",
                table: "orders",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
