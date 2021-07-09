using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.HotelId);
            builder.Property(h => h.HotelId)
                .ValueGeneratedOnAdd();

            builder.Property(h => h.Nombre)
                .IsRequired(true)
                .HasMaxLength(128);

            builder.Property(h => h.Longitud)
                .IsRequired(true)
                .HasDefaultValue(0)
                .HasPrecision(10, 7);

            builder.Property(h => h.Latitud)
                .IsRequired(true)
                .HasDefaultValue(0)
                .HasPrecision(10, 7);

            builder.Property(h => h.Provincia)
                .IsRequired(true)
                .HasMaxLength(64)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            builder.Property(h => h.Ciudad)
                .IsRequired(true)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            builder.Property(h => h.Direccion)
                .IsRequired(true)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            builder.Property(h => h.DireccionNum)
                .IsRequired(true)
                .HasMaxLength(16);

            builder.Property(h => h.DireccionObservaciones)
                .IsRequired(false)
                .HasMaxLength(128);

            builder.Property(h => h.CodigoPostal)
                .IsRequired(true)
                .HasMaxLength(24);

            builder.Property(h => h.EstrellasId)
                .IsRequired(true);

            builder.Property(h => h.Telefono)
                .IsRequired(true)
                .HasMaxLength(16);

            builder.Property(h => h.Correo)
                .IsRequired(true)
                .HasMaxLength(128);
        }
    }
}
