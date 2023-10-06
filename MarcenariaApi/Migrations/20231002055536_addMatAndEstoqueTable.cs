using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcenariaApi.Migrations
{
    /// <inheritdoc />
    public partial class addMatAndEstoqueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    custo = table.Column<double>(type: "REAL", nullable: false),
                    estoqueId = table.Column<int>(type: "INTEGER", nullable: false),
                    tarefaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.id);
                    table.ForeignKey(
                        name: "FK_Materiais_Estoques_estoqueId",
                        column: x => x.estoqueId,
                        principalTable: "Estoques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materiais_Tarefas_tarefaId",
                        column: x => x.tarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_estoqueId",
                table: "Materiais",
                column: "estoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_tarefaId",
                table: "Materiais",
                column: "tarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "Estoques");
        }
    }
}
