using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteAutoGlass.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedors",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedors", x => x.IdFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DataFabricacao = table.Column<DateTime>(nullable: false),
                    DataValidade = table.Column<DateTime>(nullable: false),
                    IdFornecedor = table.Column<int>(nullable: false),
                    fornecedoresIdFornecedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedors_fornecedoresIdFornecedor",
                        column: x => x.fornecedoresIdFornecedor,
                        principalTable: "Fornecedors",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_fornecedoresIdFornecedor",
                table: "Produtos",
                column: "fornecedoresIdFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedors");
        }
    }
}
