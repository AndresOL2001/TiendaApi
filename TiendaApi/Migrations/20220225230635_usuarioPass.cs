using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaApi.Migrations
{
    public partial class usuarioPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_detallesOrdenes",
                table: "detallesOrdenes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "detallesOrdenes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detallesOrdenes",
                table: "detallesOrdenes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_detallesOrdenes_ProductoId",
                table: "detallesOrdenes",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_detallesOrdenes",
                table: "detallesOrdenes");

            migrationBuilder.DropIndex(
                name: "IX_detallesOrdenes_ProductoId",
                table: "detallesOrdenes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "detallesOrdenes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detallesOrdenes",
                table: "detallesOrdenes",
                columns: new[] { "ProductoId", "OrdenId" });
        }
    }
}
