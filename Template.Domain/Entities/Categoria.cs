using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Entities
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Habitacion> Habitaciones { get; set; }
    }
}
