﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NT1_2023_2C_D.Models;

namespace NT1_2023_2C_D.Data
{
    public class GarageContext : IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public GarageContext(DbContextOptions options) : base(options)
        {           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");


            modelBuilder.Entity<ClienteVehiculo>()
                .HasKey( cv => new { cv.ClienteId,cv.VehiculoId } );



        }

        public DbSet<Rol> MisRoles { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<ClienteVehiculo> ClienteVehiculos { get; set; }

        public DbSet<Estancia> Estancias { get; set; }

        public DbSet<Pago> Pagos { get; set; }


    }
}
