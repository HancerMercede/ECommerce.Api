using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingLengthOf8ToSecuence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NCF_Details",
                table: "NCF_Details");

            migrationBuilder.AlterColumn<string>(
                name: "Secuence",
                table: "NCF_Details",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCF_Details",
                table: "NCF_Details",
                columns: new[] { "NCF_Serie", "NCF_Type", "Secuence" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NCF_Details",
                table: "NCF_Details");

            migrationBuilder.AlterColumn<string>(
                name: "Secuence",
                table: "NCF_Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCF_Details",
                table: "NCF_Details",
                columns: new[] { "NCF_Serie", "NCF_Type" });
        }
    }
}
