using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Entities
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        public int HotelId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public Hotel Hotel { get; set; }
        public Categoria Categoria { get; set; }
    }
}
