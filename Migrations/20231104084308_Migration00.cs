using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDVTsmV3.Migrations
{
    /// <inheritdoc />
    public partial class Migration00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Persona = table.Column<int>(type: "int", nullable: false),
                    Empleado_Id = table.Column<int>(type: "int", nullable: false),
                    FechaHora_de_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Empleado_Empleado_Id",
                        column: x => x.Empleado_Id,
                        principalTable: "Empleado",
                        principalColumn: "Empleado_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Persona",
                        principalColumn: "Persona_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Producto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unidad_De_Venta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_Producto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio_Unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad_En_Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id_Producto);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id_Venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora_Venta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHora_Entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado_Seguimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Venta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Empleado_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id_Venta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_Empleado_Id",
                        column: x => x.Empleado_Id,
                        principalTable: "Empleado",
                        principalColumn: "Empleado_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Producto",
                columns: table => new
                {
                    Id_Detalle_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_De_Uso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durabilidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estampado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Producto", x => x.Id_Detalle_Producto);
                    table.ForeignKey(
                        name: "FK_Detalle_Producto_Producto_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_de_venta",
                columns: table => new
                {
                    Id_Detalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio_Producto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_Venta = table.Column<int>(type: "int", nullable: false),
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_de_venta", x => x.Id_Detalle);
                    table.ForeignKey(
                        name: "FK_Detalle_de_venta_Producto_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_de_venta_Venta_Id_Venta",
                        column: x => x.Id_Venta,
                        principalTable: "Venta",
                        principalColumn: "Id_Venta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Empleado_Id",
                table: "Cliente",
                column: "Empleado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id_Persona",
                table: "Cliente",
                column: "Id_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_de_venta_Id_Producto",
                table: "Detalle_de_venta",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_de_venta_Id_Venta",
                table: "Detalle_de_venta",
                column: "Id_Venta");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Producto_Id_Producto",
                table: "Detalle_Producto",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Empleado_Id",
                table: "Venta",
                column: "Empleado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Id_Cliente",
                table: "Venta",
                column: "Id_Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_de_venta");

            migrationBuilder.DropTable(
                name: "Detalle_Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
