using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDVTsmV3.Migrations
{
    /// <inheritdoc />
    public partial class Migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Usuario_Id",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Usuario_Id",
                table: "Empleado",
                column: "Usuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Usuario_Usuario_Id",
                table: "Empleado",
                column: "Usuario_Id",
                principalTable: "Usuario",
                principalColumn: "Usuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Usuario_Usuario_Id",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Usuario_Id",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Usuario_Id",
                table: "Empleado");
        }
    }
}
