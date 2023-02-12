using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingFactorUnitToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Products",
                newName: "unitId");

            migrationBuilder.AddColumn<int>(
                name: "UnitsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitsId",
                table: "Products",
                column: "UnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitsId",
                table: "Products",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitsId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "unitId",
                table: "Products",
                newName: "Size");
        }
    }
}
