using Microsoft.EntityFrameworkCore.Migrations;

namespace Aula10_relacionamento1toN.Migrations
{
    public partial class n1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afiliado",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    ResponsavelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependente_Afiliado_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Afiliado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_ResponsavelId",
                table: "Dependente",
                column: "ResponsavelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Afiliado");
        }
    }
}
