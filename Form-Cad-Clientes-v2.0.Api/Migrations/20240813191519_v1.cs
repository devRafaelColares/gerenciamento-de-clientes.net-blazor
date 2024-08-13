using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Form_Cad_Clientes_v2._0.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CidadeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CidadesId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Clientes_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Cidades_CidadesId",
                        column: x => x.CidadesId,
                        principalTable: "Cidades",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[,]
                {
                    { 1L, "SP", "São Paulo" },
                    { 2L, "RJ", "Rio de Janeiro" },
                    { 3L, "MG", "Belo Horizonte" },
                    { 4L, "PR", "Curitiba" },
                    { 5L, "RS", "Porto Alegre" },
                    { 6L, "BA", "Salvador" },
                    { 7L, "PE", "Recife" },
                    { 8L, "CE", "Fortaleza" },
                    { 9L, "DF", "Brasília" },
                    { 10L, "GO", "Goiânia" },
                    { 11L, "AM", "Manaus" },
                    { 12L, "PA", "Belém" },
                    { 13L, "ES", "Vitória" },
                    { 14L, "SC", "Florianópolis" },
                    { 15L, "RN", "Natal" },
                    { 16L, "PB", "João Pessoa" },
                    { 17L, "PI", "Teresina" },
                    { 18L, "MS", "Campo Grande" },
                    { 19L, "MT", "Cuiabá" },
                    { 20L, "MA", "São Luís" },
                    { 21L, "TO", "Palmas" },
                    { 22L, "RR", "Boa Vista" },
                    { 23L, "AP", "Macapá" },
                    { 24L, "RO", "Porto Velho" },
                    { 25L, "AC", "Rio Branco" },
                    { 26L, "TO", "Araguaína" },
                    { 27L, "AL", "Arapiraca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CidadeId",
                table: "Clientes",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CidadesId",
                table: "Clientes",
                column: "CidadesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
