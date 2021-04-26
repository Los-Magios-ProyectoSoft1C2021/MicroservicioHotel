using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.AccessData.Configuration;

namespace MicroservicioHotel.AccessData
{
    public class BookingUnajDbContext : DbContext
    {
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FotoHotel> FotosHoteles { get; set; }

        public BookingUnajDbContext(DbContextOptions<BookingUnajDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Hotel>(new HotelConfiguration());

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
        }
    }
}
