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

            builder.HasData(
                new Categoria { CategoriaId = 1 ,Nombre = "Individual", Descripcion = "Habitación para una persona" },
                new Categoria { CategoriaId = 2, Nombre = "Matrimonial", Descripcion = "Habitación para dos personas" },
                new Categoria { CategoriaId = 3, Nombre = "Suite", Descripcion = "Habitación para cuatro personas" }
                );
        }
    }
}
