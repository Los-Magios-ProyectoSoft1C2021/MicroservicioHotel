using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.CategoriaId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nombre)
                .IsRequired(true)
                .HasMaxLength(64);

            builder.Property(c => c.Descripcion)
                .IsRequired(true)
                .HasMaxLength(128);

            builder.HasMany<Habitacion>(c => c.Habitaciones)
                .WithOne(h => h.Categoria)
                .HasForeignKey(h => h.CategoriaId);
        }
    }
}
