using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingNameToFactorAndForeingKeyToFactorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId_ProductFactorId_ProductFruitId",
                table: "InvoiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Fruits_FruitId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitsId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FruitId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_ProductId_ProductFactorId_ProductFruitId",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "UnitsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductFactorId",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "ProductFruitId",
                table: "InvoiceDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactorId",
                table: "Products",
                column: "FactorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_FactorId",
                table: "Products",
                column: "FactorId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_FactorId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FactorId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "UnitsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductFactorId",
                table: "InvoiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductFruitId",
                table: "InvoiceDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                columns: new[] { "Id", "FactorId", "FruitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FruitId",
                table: "Products",
                column: "FruitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitsId",
                table: "Products",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId_ProductFactorId_ProductFruitId",
                table: "InvoiceDetail",
                columns: new[] { "ProductId", "ProductFactorId", "ProductFruitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId_ProductFactorId_ProductFruitId",
                table: "InvoiceDetail",
                columns: new[] { "ProductId", "ProductFactorId", "ProductFruitId" },
                principalTable: "Products",
                principalColumns: new[] { "Id", "FactorId", "FruitId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Fruits_FruitId",
                table: "Products",
                column: "FruitId",
                principalTable: "Fruits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitsId",
                table: "Products",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
