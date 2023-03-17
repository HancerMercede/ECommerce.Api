using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "NCF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NCF_Details",
                columns: table => new
                {
                    NCFSerie = table.Column<string>(name: "NCF_Serie", type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NCFType = table.Column<string>(name: "NCF_Type", type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NCFId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCF_Details", x => new { x.NCFSerie, x.NCFType });
                    table.ForeignKey(
                        name: "FK_NCF_Details_NCF_NCFId",
                        column: x => x.NCFId,
                        principalTable: "NCF",
                        principalColumn: "Id");
                });

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
                name: "IX_NCF_Details_NCFId",
                table: "NCF_Details",
                column: "NCFId");

            migrationBuilder.CreateIndex(
                name: "IX_NCF_Secuence_NCFId",
                table: "NCF_Secuence",
                column: "NCFId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NCF_Details");

            migrationBuilder.DropTable(
                name: "NCF_Secuence");

            migrationBuilder.DropTable(
                name: "NCF");
        }
    }
}
