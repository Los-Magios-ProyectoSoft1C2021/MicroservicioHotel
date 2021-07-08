using System.Collections.Generic;

namespace MicroservicioHotel.Domain.Entities
{
    public class Estrellas
    {
        public int EstrellasId { get; set; }
        public int CantidadEstrellas { get; set; }

        public List<ServicioEstrellas> Servicios { get; set; }
    }
}
