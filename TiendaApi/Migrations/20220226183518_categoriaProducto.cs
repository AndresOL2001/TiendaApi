using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaApi.Migrations
{
    public partial class categoriaProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_CategoriaId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_CategoriaId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "productos");

            migrationBuilder.CreateTable(
                name: "categoriaProductos",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaProductos", x => new { x.categoriaId, x.productoId });
                    table.ForeignKey(
                        name: "FK_categoriaProductos_categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriaProductos_productos_productoId",
                        column: x => x.productoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoriaProductos_productoId",
                table: "categoriaProductos",
                column: "productoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriaProductos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaId",
                table: "productos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_CategoriaId",
                table: "productos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
