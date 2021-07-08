using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class EstrellasConfiguration : IEntityTypeConfiguration<Estrellas>
    {
        public void Configure(EntityTypeBuilder<Estrellas> builder)
        {
            builder.HasKey(e => e.EstrellasId);

            builder.Property(e => e.EstrellasId)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CantidadEstrellas)
                .IsRequired();

            builder.HasMany(e => e.Servicios)
                .WithOne(se => se.Estrellas)
                .HasForeignKey(se => se.EstrellasId);

            builder.HasData(
                new Estrellas { EstrellasId = 1, CantidadEstrellas = 1 },
                new Estrellas { EstrellasId = 2, CantidadEstrellas = 2 },
                new Estrellas { EstrellasId = 3, CantidadEstrellas = 3 },
                new Estrellas { EstrellasId = 4, CantidadEstrellas = 4 },
                new Estrellas { EstrellasId = 5, CantidadEstrellas = 5 }
                );
        }
    }
}
