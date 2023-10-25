﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NT1_2023_2C_D.Data;

#nullable disable

namespace NT1_2023_2C_D.Migrations
{
    [DbContext(typeof(GarageContext))]
    [Migration("20231024225646_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Personas", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("PersonasRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.ClienteVehiculo", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "VehiculoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("ClienteVehiculos");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Piso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Estancia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Estancias");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EstanciaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EstanciaId")
                        .IsUnique();

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Telefono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodArea")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnioFabricacion")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Persona", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser<int>");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("Persona");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole<int>");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Cliente", b =>
                {
                    b.HasBaseType("NT1_2023_2C_D.Models.Persona");

                    b.Property<long>("CUIT")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Empleado", b =>
                {
                    b.HasBaseType("NT1_2023_2C_D.Models.Persona");

                    b.Property<string>("CodigoEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.ClienteVehiculo", b =>
                {
                    b.HasOne("NT1_2023_2C_D.Models.Cliente", "Cliente")
                        .WithMany("ClientesVehiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NT1_2023_2C_D.Models.Vehiculo", "Vehiculo")
                        .WithMany("ClientesVehiculos")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Direccion", b =>
                {
                    b.HasOne("NT1_2023_2C_D.Models.Cliente", "Cliente")
                        .WithOne("Direccion")
                        .HasForeignKey("NT1_2023_2C_D.Models.Direccion", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Estancia", b =>
                {
                    b.HasOne("NT1_2023_2C_D.Models.Cliente", "Cliente")
                        .WithMany("Estancias")
                        .HasForeignKey("ClienteId");

                    b.HasOne("NT1_2023_2C_D.Models.Vehiculo", "Vehiculo")
                        .WithMany("Estancias")
                        .HasForeignKey("VehiculoId");

                    b.Navigation("Cliente");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Pago", b =>
                {
                    b.HasOne("NT1_2023_2C_D.Models.Estancia", "Estancia")
                        .WithOne("Pago")
                        .HasForeignKey("NT1_2023_2C_D.Models.Pago", "EstanciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estancia");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Telefono", b =>
                {
                    b.HasOne("NT1_2023_2C_D.Models.Persona", "Persona")
                        .WithMany("Telefonos")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Estancia", b =>
                {
                    b.Navigation("Pago");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Vehiculo", b =>
                {
                    b.Navigation("ClientesVehiculos");

                    b.Navigation("Estancias");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Persona", b =>
                {
                    b.Navigation("Telefonos");
                });

            modelBuilder.Entity("NT1_2023_2C_D.Models.Cliente", b =>
                {
                    b.Navigation("ClientesVehiculos");

                    b.Navigation("Direccion");

                    b.Navigation("Estancias");
                });
#pragma warning restore 612, 618
        }
    }
}