using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingNameandcomposekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NCFs",
                table: "NCFs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NCFs");

            migrationBuilder.AlterColumn<string>(
                name: "Tcomprobante",
                table: "NCFs",
                type: "char(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Serie",
                table: "NCFs",
                type: "char(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Secuence",
                table: "NCFs",
                type: "char(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "NCFs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCFs",
                table: "NCFs",
                columns: new[] { "Serie", "Tcomprobante", "Secuence" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NCFs",
                table: "NCFs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "NCFs");

            migrationBuilder.AlterColumn<string>(
                name: "Secuence",
                table: "NCFs",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Tcomprobante",
                table: "NCFs",
                type: "char(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Serie",
                table: "NCFs",
                type: "char(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldMaxLength: 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "NCFs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCFs",
                table: "NCFs",
                column: "Id");
        }
    }
}
