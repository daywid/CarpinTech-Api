using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcenariaApi.Migrations
{
    /// <inheritdoc />
    public partial class FinanceiroTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustosMateriais = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalariosFuncionarios = table.Column<decimal>(type: "TEXT", nullable: false),
                    PagamentosClientes = table.Column<decimal>(type: "TEXT", nullable: false),
                    DespesasOperacionais = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiros");
        }
    }
}
