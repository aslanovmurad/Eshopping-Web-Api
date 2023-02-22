using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShoppingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "productId",
                table: "files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_files_productId",
                table: "files",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_files_products_productId",
                table: "files",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_files_products_productId",
                table: "files");

            migrationBuilder.DropIndex(
                name: "IX_files_productId",
                table: "files");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "files");
        }
    }
}
