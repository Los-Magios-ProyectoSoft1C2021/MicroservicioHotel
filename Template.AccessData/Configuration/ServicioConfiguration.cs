using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.HasKey(s => s.ServicioId);
            builder.Property(s => s.ServicioId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Descripcion)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.HasData(
                new Servicio { ServicioId = 1, Descripcion = "Wi-Fi" },
                new Servicio { ServicioId = 2, Descripcion = "Piscina" },
                new Servicio { ServicioId = 3, Descripcion = "Servicio de guarda-equipaje" },
                new Servicio { ServicioId = 4, Descripcion = "Desayuno" },
                new Servicio { ServicioId = 5, Descripcion = "Ascensor" },
                new Servicio { ServicioId = 6, Descripcion = "Recepción 24 hs" },
                new Servicio { ServicioId = 7, Descripcion = "Recepción de paquetes gratis" },
                new Servicio { ServicioId = 8, Descripcion = "Servicio a la habitación" },

                new Servicio { ServicioId = 9, Descripcion = "Servicio de traslado en los alrededores (con costo adicional)" },                
                new Servicio { ServicioId = 10, Descripcion = "Servicio de planchado" },
                new Servicio { ServicioId = 11, Descripcion = "Servicio de lavandería (con costo adicional)" },
                new Servicio { ServicioId = 12, Descripcion = "Servicio de tintorería (con costo adicional)" },
                new Servicio { ServicioId = 13, Descripcion = "Servicio de despertador" },
                new Servicio { ServicioId = 14, Descripcion = "Casino" },
                new Servicio { ServicioId = 15, Descripcion = "Servicio de masajes" },
                new Servicio { ServicioId = 16, Descripcion = "Baño/tina de hidromasaje" },
                new Servicio { ServicioId = 17, Descripcion = "Spa" },
                new Servicio { ServicioId = 18, Descripcion = "Salón de juegos" },
                new Servicio { ServicioId = 19, Descripcion = "Gimnasio" },
                new Servicio { ServicioId = 20, Descripcion = "Sauna" },
                new Servicio { ServicioId = 21, Descripcion = "TV en zonas comunes" },

                new Servicio { ServicioId = 22, Descripcion = "Aire acondicionado en zonas comunes"},
                new Servicio { ServicioId = 23, Descripcion = "Calefacción en zonas comunes" }
                );
        }
    }
}
