using Microsoft.EntityFrameworkCore.Migrations;

namespace Productos.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[] { 1, "Arroz", 2500 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[] { 2, "Salsa de Tomate", 3000 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[] { 3, "Huevo", 450 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
