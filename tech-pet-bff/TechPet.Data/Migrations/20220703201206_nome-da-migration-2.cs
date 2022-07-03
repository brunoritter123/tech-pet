using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPet.Data.Migrations
{
    public partial class nomedamigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorDeVeiculo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorDeVeiculo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CorDeVeiculo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { (short)1, "Prata" },
                    { (short)2, "Preto" },
                    { (short)3, "Vermelho" },
                    { (short)4, "Verde" },
                    { (short)5, "Laranja" },
                    { (short)6, "Azul" },
                    { (short)7, "Branco" },
                    { (short)8, "Cinza" },
                    { (short)9, "Marrom" },
                    { (short)10, "Bege" },
                    { (short)11, "Dourado" },
                    { (short)12, "Rosa" },
                    { (short)13, "Roxo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorDeVeiculo");
        }
    }
}
