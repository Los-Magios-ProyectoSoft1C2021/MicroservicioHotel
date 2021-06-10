using MicroservicioHotel.AccessData.Configuration;
using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicioHotel.AccessData
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<FotoHotel> FotoHotel { get; set; }

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
