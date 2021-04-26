using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Entities
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }

        public Guid HotelId { get; set; }

        public Guid CategoriaId { get; set; }

        public string Nombre { get; set; }


        // Relación con la tabla Hotel
        public Hotel Hotel { get; set; }

        // Relación con la tabla Categoria
        public Categoria Categoria { get; set; }

        // Relación con la tabla Reservas
        public List<Reserva> Reservas { get; set; }
    }
}
