using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Entities
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        public Guid HotelId { get; set; }
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }

        public Hotel Hotel { get; set; }
        public Categoria Categoria { get; set; }
    }
}
