using System.Collections.Generic;

namespace MicroservicioHotel.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
    }
}
