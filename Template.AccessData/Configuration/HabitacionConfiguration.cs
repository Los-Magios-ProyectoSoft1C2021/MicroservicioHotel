using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.HasKey(h => h.HabitacionId);
            builder.Property(h => h.HabitacionId)
                .ValueGeneratedOnAdd();

            builder.Property(h => h.CategoriaId)
                .IsRequired(true);

            builder.Property(h => h.Nombre)
                .IsRequired(true)
                .HasMaxLength(64);
        }
    }
}
