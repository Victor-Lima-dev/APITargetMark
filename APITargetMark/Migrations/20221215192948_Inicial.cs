using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITargetMark.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MensagensVisualizadas = table.Column<int>(type: "int", nullable: false),
                    MensagensInteragidas = table.Column<int>(type: "int", nullable: false),
                    TaxaConversao = table.Column<int>(type: "int", nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.RelatorioId);
                });

            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantidadeMensagens = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublicoAlvo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.CampanhaId);
                    table.ForeignKey(
                        name: "FK_Campanhas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Regiao = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "CampanhaId");
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    MensagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CampanhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.MensagemId);
                    table.ForeignKey(
                        name: "FK_Mensagens_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "CampanhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_EmpresaId",
                table: "Campanhas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CampanhaId",
                table: "Clientes",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_CampanhaId",
                table: "Mensagens",
                column: "CampanhaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
