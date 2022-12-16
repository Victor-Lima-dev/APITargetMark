using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITargetMark.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Empresas_EmpresaId",
                table: "Campanhas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Campanhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Empresas_EmpresaId",
                table: "Campanhas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Empresas_EmpresaId",
                table: "Campanhas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Campanhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Empresas_EmpresaId",
                table: "Campanhas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
