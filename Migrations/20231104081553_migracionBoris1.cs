using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDVTsmV3.Migrations
{
    /// <inheritdoc />
    public partial class migracionBoris1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Persona_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ci = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Nac = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Persona_Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Rol_Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usuario_Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Rol",
                        principalColumn: "Rol_Id");
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Empleado_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: true),
                    Usuario_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Empleado_Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Persona_Persona_Id",
                        column: x => x.Persona_Id,
                        principalTable: "Persona",
                        principalColumn: "Persona_Id");
                    table.ForeignKey(
                        name: "FK_Empleado_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Usuario_Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Rol_Id",
                table: "Usuario",
                column: "Rol_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
