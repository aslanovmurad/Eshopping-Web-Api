using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShoppingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ProductProductImageFile",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productImageFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductImageFile", x => new { x.productId, x.productImageFilesId });
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_files_productImageFilesId",
                        column: x => x.productImageFilesId,
                        principalTable: "files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductImageFile_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductImageFile_productImageFilesId",
                table: "ProductProductImageFile",
                column: "productImageFilesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductImageFile");

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
    }
}
