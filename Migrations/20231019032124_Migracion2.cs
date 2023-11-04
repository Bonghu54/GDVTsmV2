﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDVTsmV3.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Persona_Id",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Persona_Id",
                table: "Empleado",
                column: "Persona_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Persona_Persona_Id",
                table: "Empleado",
                column: "Persona_Id",
                principalTable: "Persona",
                principalColumn: "Persona_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Persona_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Persona_Id",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Persona_Id",
                table: "Empleado");
        }
    }
}
