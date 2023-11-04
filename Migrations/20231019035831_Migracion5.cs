using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDVTsmV3.Migrations
{
    /// <inheritdoc />
    public partial class Migracion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Persona_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Usuario_Usuario_Id",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Usuario_Id",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_Id",
                table: "Empleado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Persona_Id",
                table: "Empleado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Persona_Id",
                table: "Empleado",
                column: "Persona_Id",
                unique: true,
                filter: "[Persona_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Usuario_Id",
                table: "Empleado",
                column: "Usuario_Id",
                unique: true,
                filter: "[Usuario_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Persona_Persona_Id",
                table: "Empleado",
                column: "Persona_Id",
                principalTable: "Persona",
                principalColumn: "Persona_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Usuario_Usuario_Id",
                table: "Empleado",
                column: "Usuario_Id",
                principalTable: "Usuario",
                principalColumn: "Usuario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Persona_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Usuario_Usuario_Id",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Usuario_Id",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_Id",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Persona_Id",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Persona_Id",
                table: "Empleado",
                column: "Persona_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Usuario_Id",
                table: "Empleado",
                column: "Usuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Persona_Persona_Id",
                table: "Empleado",
                column: "Persona_Id",
                principalTable: "Persona",
                principalColumn: "Persona_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Usuario_Usuario_Id",
                table: "Empleado",
                column: "Usuario_Id",
                principalTable: "Usuario",
                principalColumn: "Usuario_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
