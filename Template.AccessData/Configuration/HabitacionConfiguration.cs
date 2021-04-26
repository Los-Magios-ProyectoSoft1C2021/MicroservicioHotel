using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder.HasOne<Categoria>(h => h.Categoria)
                .WithMany(c => c.Habitaciones)
                .HasForeignKey(h => h.CategoriaId);

            builder.HasOne<Hotel>(ha => ha.Hotel)
                .WithMany(ho => ho.Habitaciones)
                .HasForeignKey(ha => ha.HotelId);
        }
    }
}
