using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class FotoHotelConfiguration : IEntityTypeConfiguration<FotoHotel>
    {
        public void Configure(EntityTypeBuilder<FotoHotel> builder)
        {
            builder.HasKey(fh => fh.FotoHotelId);
            builder.Property(fh => fh.FotoHotelId)
                .ValueGeneratedOnAdd();

            builder.Property(fh => fh.ImagenUrl)
                .IsRequired(true)
                .HasMaxLength(128);

            builder.Property(fh => fh.Descripcion)
                .IsRequired(true)
                .HasMaxLength(128);
        }
    }
}
