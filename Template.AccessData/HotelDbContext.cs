using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.AccessData.Configuration;

namespace MicroservicioHotel.AccessData
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FotoHotel> FotosHoteles { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration<FotoHotel>(new FotoHotelConfiguration());
            modelBuilder.ApplyConfiguration<Habitacion>(new HabitacionConfiguration());
            modelBuilder.ApplyConfiguration<Hotel>(new HotelConfiguration());
        }
    }
}
