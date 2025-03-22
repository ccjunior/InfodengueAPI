using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfodengueAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arbovirose = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    SemanaInicio = table.Column<int>(type: "int", nullable: false),
                    SemanaFim = table.Column<int>(type: "int", nullable: false),
                    CodigoIBGE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DadosConsulta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorios_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_SolicitanteId",
                table: "Relatorios",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitantes_CPF",
                table: "Solicitantes",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Solicitantes");
        }
    }
}
