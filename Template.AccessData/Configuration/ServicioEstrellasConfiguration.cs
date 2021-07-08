using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class ServicioEstrellasConfiguration : IEntityTypeConfiguration<ServicioEstrellas>
    {
        public void Configure(EntityTypeBuilder<ServicioEstrellas> builder)
        {
            builder.HasKey(se => se.ServicioEstrellaId);

            builder.Property(se => se.ServicioEstrellaId)
                .ValueGeneratedOnAdd();

            builder.HasOne(se => se.Servicio)
                .WithMany()
                .HasForeignKey(se => se.ServicioId);

            builder.HasOne(se => se.Estrellas)
                .WithMany(e => e.Servicios)
                .HasForeignKey(se => se.EstrellasId)
                .IsRequired();

            builder.HasData(
                new ServicioEstrellas { ServicioEstrellaId = 1, EstrellasId = 5, ServicioId = 1 },
                new ServicioEstrellas { ServicioEstrellaId = 2, EstrellasId = 5, ServicioId = 2 },
                new ServicioEstrellas { ServicioEstrellaId = 3, EstrellasId = 5, ServicioId = 3 },
                new ServicioEstrellas { ServicioEstrellaId = 4, EstrellasId = 5, ServicioId = 4 },
                new ServicioEstrellas { ServicioEstrellaId = 5, EstrellasId = 5, ServicioId = 5 },
                new ServicioEstrellas { ServicioEstrellaId = 6, EstrellasId = 5, ServicioId = 6 },
                new ServicioEstrellas { ServicioEstrellaId = 7, EstrellasId = 5, ServicioId = 7 },
                new ServicioEstrellas { ServicioEstrellaId = 8, EstrellasId = 5, ServicioId = 8 },
                new ServicioEstrellas { ServicioEstrellaId = 9, EstrellasId = 5, ServicioId = 9 },
                new ServicioEstrellas { ServicioEstrellaId = 10, EstrellasId = 5, ServicioId = 10 },
                new ServicioEstrellas { ServicioEstrellaId = 11, EstrellasId = 5, ServicioId = 11 },
                new ServicioEstrellas { ServicioEstrellaId = 12, EstrellasId = 5, ServicioId = 12 },
                new ServicioEstrellas { ServicioEstrellaId = 13, EstrellasId = 5, ServicioId = 13 },
                new ServicioEstrellas { ServicioEstrellaId = 14, EstrellasId = 5, ServicioId = 14 },
                new ServicioEstrellas { ServicioEstrellaId = 15, EstrellasId = 5, ServicioId = 15 },
                new ServicioEstrellas { ServicioEstrellaId = 16, EstrellasId = 5, ServicioId = 16 },
                new ServicioEstrellas { ServicioEstrellaId = 17, EstrellasId = 5, ServicioId = 17 },
                new ServicioEstrellas { ServicioEstrellaId = 18, EstrellasId = 5, ServicioId = 18 },
                new ServicioEstrellas { ServicioEstrellaId = 19, EstrellasId = 5, ServicioId = 19 },
                new ServicioEstrellas { ServicioEstrellaId = 20, EstrellasId = 5, ServicioId = 20 },
                new ServicioEstrellas { ServicioEstrellaId = 21, EstrellasId = 5, ServicioId = 21 },
                new ServicioEstrellas { ServicioEstrellaId = 22, EstrellasId = 5, ServicioId = 22 },
                new ServicioEstrellas { ServicioEstrellaId = 23, EstrellasId = 5, ServicioId = 23 },

                new ServicioEstrellas { ServicioEstrellaId = 24, EstrellasId = 4, ServicioId = 1 },
                new ServicioEstrellas { ServicioEstrellaId = 25, EstrellasId = 4, ServicioId = 2 },
                new ServicioEstrellas { ServicioEstrellaId = 26, EstrellasId = 4, ServicioId = 3 },
                new ServicioEstrellas { ServicioEstrellaId = 27, EstrellasId = 4, ServicioId = 4 },
                new ServicioEstrellas { ServicioEstrellaId = 28, EstrellasId = 4, ServicioId = 5 },
                new ServicioEstrellas { ServicioEstrellaId = 29, EstrellasId = 4, ServicioId = 6 },
                new ServicioEstrellas { ServicioEstrellaId = 30, EstrellasId = 4, ServicioId = 8 },
                new ServicioEstrellas { ServicioEstrellaId = 31, EstrellasId = 4, ServicioId = 10 },
                new ServicioEstrellas { ServicioEstrellaId = 32, EstrellasId = 4, ServicioId = 13 },
                new ServicioEstrellas { ServicioEstrellaId = 33, EstrellasId = 4, ServicioId = 18 },
                new ServicioEstrellas { ServicioEstrellaId = 34, EstrellasId = 4, ServicioId = 19 },
                new ServicioEstrellas { ServicioEstrellaId = 35, EstrellasId = 4, ServicioId = 21 },

                new ServicioEstrellas { ServicioEstrellaId = 36, EstrellasId = 3, ServicioId = 1 },
                new ServicioEstrellas { ServicioEstrellaId = 37, EstrellasId = 3, ServicioId = 4 },
                new ServicioEstrellas { ServicioEstrellaId = 38, EstrellasId = 3, ServicioId = 6 },
                new ServicioEstrellas { ServicioEstrellaId = 39, EstrellasId = 3, ServicioId = 8 },
                new ServicioEstrellas { ServicioEstrellaId = 40, EstrellasId = 3, ServicioId = 18 },
                new ServicioEstrellas { ServicioEstrellaId = 41, EstrellasId = 3, ServicioId = 21 },

                new ServicioEstrellas { ServicioEstrellaId = 42, EstrellasId = 2, ServicioId = 1 },
                new ServicioEstrellas { ServicioEstrellaId = 43, EstrellasId = 3, ServicioId = 6 },
                new ServicioEstrellas { ServicioEstrellaId = 44, EstrellasId = 2, ServicioId = 4 },
                new ServicioEstrellas { ServicioEstrellaId = 45, EstrellasId = 2, ServicioId = 8 },
                new ServicioEstrellas { ServicioEstrellaId = 46, EstrellasId = 2, ServicioId = 21 },

                new ServicioEstrellas { ServicioEstrellaId = 47, EstrellasId = 1, ServicioId = 1 },
                new ServicioEstrellas { ServicioEstrellaId = 48, EstrellasId = 1, ServicioId = 4 },
                new ServicioEstrellas { ServicioEstrellaId = 49, EstrellasId = 1, ServicioId = 6 }
                );
        }
    }
}
