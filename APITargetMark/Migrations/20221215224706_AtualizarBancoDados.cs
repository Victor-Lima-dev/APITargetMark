using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITargetMark.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarBancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Relatorios");
        }
    }
}
