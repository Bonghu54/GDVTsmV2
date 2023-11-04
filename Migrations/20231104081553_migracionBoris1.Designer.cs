﻿// <auto-generated />
using System;
using GDVTsmV3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GDVTsmV3.Migrations
{
    [DbContext(typeof(GDVTsmV3Context))]
    [Migration("20231104081553_migracionBoris1")]
    partial class migracionBoris1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GDVTsmV3.Models.Empleado", b =>
                {
                    b.Property<int>("Empleado_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Empleado_Id"));

                    b.Property<int?>("Persona_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Usuario_Id")
                        .HasColumnType("int");

                    b.HasKey("Empleado_Id");

                    b.HasIndex("Persona_Id")
                        .IsUnique()
                        .HasFilter("[Persona_Id] IS NOT NULL");

                    b.HasIndex("Usuario_Id")
                        .IsUnique()
                        .HasFilter("[Usuario_Id] IS NOT NULL");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Persona", b =>
                {
                    b.Property<int>("Persona_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Persona_Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ci")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Nac")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Persona_Id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Rol", b =>
                {
                    b.Property<int>("Rol_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rol_Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Rol_Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Usuario", b =>
                {
                    b.Property<int>("Usuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usuario_Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo_Electronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rol_Id")
                        .HasColumnType("int");

                    b.HasKey("Usuario_Id");

                    b.HasIndex("Rol_Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Empleado", b =>
                {
                    b.HasOne("GDVTsmV3.Models.Persona", "Persona")
                        .WithOne("Empleado")
                        .HasForeignKey("GDVTsmV3.Models.Empleado", "Persona_Id");

                    b.HasOne("GDVTsmV3.Models.Usuario", "Usuario")
                        .WithOne("Empleado")
                        .HasForeignKey("GDVTsmV3.Models.Empleado", "Usuario_Id");

                    b.Navigation("Persona");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Usuario", b =>
                {
                    b.HasOne("GDVTsmV3.Models.Rol", "Rol")
                        .WithMany("Usuario")
                        .HasForeignKey("Rol_Id");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Persona", b =>
                {
                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Rol", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GDVTsmV3.Models.Usuario", b =>
                {
                    b.Navigation("Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
