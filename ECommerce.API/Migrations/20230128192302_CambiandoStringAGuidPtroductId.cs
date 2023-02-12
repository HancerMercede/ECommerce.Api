using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class CambiandoStringAGuidPtroductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId1",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_ProductId1",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "InvoiceDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "InvoiceDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "InvoiceDetail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "InvoiceDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId1",
                table: "InvoiceDetail",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId1",
                table: "InvoiceDetail",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
