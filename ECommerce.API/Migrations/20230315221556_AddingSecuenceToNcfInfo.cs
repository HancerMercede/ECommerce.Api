using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingSecuenceToNcfInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NCF_Secuence");

            migrationBuilder.AddColumn<string>(
                name: "Active",
                table: "NCF_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Secuence",
                table: "NCF_Details",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "NCF_Details");

            migrationBuilder.DropColumn(
                name: "Secuence",
                table: "NCF_Details");

            migrationBuilder.CreateTable(
                name: "NCF_Secuence",
                columns: table => new
                {
                    NCFSerie = table.Column<string>(name: "NCF_Serie", type: "nvarchar(450)", nullable: false),
                    NCFType = table.Column<string>(name: "NCF_Type", type: "nvarchar(450)", nullable: false),
                    Secuence = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Y"),
                    NCFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCF_Secuence", x => new { x.NCFSerie, x.NCFType, x.Secuence });
                    table.ForeignKey(
                        name: "FK_NCF_Secuence_NCF_NCFId",
                        column: x => x.NCFId,
                        principalTable: "NCF",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NCF_Secuence_NCFId",
                table: "NCF_Secuence",
                column: "NCFId");
        }
    }
}
