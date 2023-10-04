using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturacion.Migrations
{
    /// <inheritdoc />
    public partial class FactDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Detalle_idFactura",
                table: "Detalle",
                column: "idFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_idProducto",
                table: "Detalle",
                column: "idProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Factura_idFactura",
                table: "Detalle",
                column: "idFactura",
                principalTable: "Factura",
                principalColumn: "idFactura",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Producto_idProducto",
                table: "Detalle",
                column: "idProducto",
                principalTable: "Producto",
                principalColumn: "idProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Factura_idFactura",
                table: "Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Producto_idProducto",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_idFactura",
                table: "Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_idProducto",
                table: "Detalle");
        }
    }
}
