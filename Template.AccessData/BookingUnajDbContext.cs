using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Template.AccessData
{
    public class BookingUnajDbContext : DbContext
    {
        public BookingUnajDbContext(DbContextOptions<BookingUnajDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hoteles { get; set; }

        public DbSet<Habitacion> Habitaciones { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<FotoHotel> FotosHotel { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(hotel =>
            {
                hotel.Property(p => p.Nombre).IsRequired(true).HasMaxLength(64);
                hotel.Property(p => p.Longitud).IsRequired(true).HasDefaultValue(0).HasPrecision(10, 7);
                hotel.Property(p => p.Latitud).IsRequired(true).HasDefaultValue(0).HasPrecision(10, 7);
                hotel.Property(p => p.Provincia).IsRequired(true).HasMaxLength(64);
                hotel.Property(p => p.Ciudad).IsRequired(true).HasMaxLength(128);
                hotel.Property(p => p.Direccion).IsRequired(true).HasMaxLength(128);
                hotel.Property(p => p.DireccionNum).IsRequired(true).HasMaxLength(16);
                hotel.Property(p => p.DireccionObservaciones).IsRequired(false).HasMaxLength(128);
                hotel.Property(p => p.CodigoPostal).IsRequired(true).HasMaxLength(24);
                hotel.Property(p => p.Estrellas).IsRequired(true);
                hotel.Property(p => p.Telefono).IsRequired(true).HasMaxLength(16);
                hotel.Property(p => p.Correo).IsRequired(true).HasMaxLength(128);
            });

            modelBuilder.Entity<FotoHotel>(fh =>
            {
                fh.Property(p => p.ImagenUrl).IsRequired(true).HasMaxLength(128);
                fh.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(128);
            });

            modelBuilder.Entity<Habitacion>(habitacion =>
            {
                habitacion.Property(p => p.Nombre).IsRequired(true).HasMaxLength(64);
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.Property(p => p.Nombre).IsRequired(true).HasMaxLength(64);
                categoria.Property(p => p.Descripcion).IsRequired(true).HasMaxLength(128);
            });

            modelBuilder.Entity<Reserva>(reserva =>
            {
                reserva.Property(p => p.FechaInicio).IsRequired(true);
                reserva.Property(p => p.FechaFin).IsRequired(true);
            });

            modelBuilder.Entity<Rol>(rol =>
            {
                rol.Property(p => p.Nombre).IsRequired(true).HasMaxLength(24);
                rol.Property(p => p.Descripcion).IsRequired(true).HasMaxLength(128);
            });

            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.Property(p => p.Nombre).IsRequired(true).HasMaxLength(64);
                usuario.Property(p => p.Apellido).IsRequired(true).HasMaxLength(64);
                usuario.Property(p => p.Dni).IsRequired(true);
                usuario.Property(p => p.NombreUsuario).IsRequired(true).HasMaxLength(64);
                usuario.Property(p => p.Contraseña).IsRequired(true).HasMaxLength(64);
                usuario.Property(p => p.Correo).IsRequired(true).HasMaxLength(128);
                usuario.Property(p => p.Telefono).IsRequired(true).HasMaxLength(16);
                usuario.Property(p => p.Imagen).IsRequired(true).HasMaxLength(128);
                usuario.Property(p => p.Nacionalidad).IsRequired(true).HasMaxLength(128);
            });
        }
    }
}
