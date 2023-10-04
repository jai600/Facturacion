using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturacion.Migrations
{
    /// <inheritdoc />
    public partial class FactDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Detaalle",
                table: "Detaalle");

            migrationBuilder.RenameTable(
                name: "Detaalle",
                newName: "Detalle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detalle",
                table: "Detalle",
                column: "idDetalle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Detalle",
                table: "Detalle");

            migrationBuilder.RenameTable(
                name: "Detalle",
                newName: "Detaalle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detaalle",
                table: "Detaalle",
                column: "idDetalle");
        }
    }
}
