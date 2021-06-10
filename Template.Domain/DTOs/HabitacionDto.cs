using MicroservicioHotel.Domain.Entities;
using System;

namespace MicroservicioHotel.Domain.DTOs
{
    public class HabitacionDto
    {
        public int HabitacionId { get; set; }

        public Guid HotelId { get; set; }

        public Guid CategoriaId { get; set; }

        public string Nombre { get; set; }


        // Relación con la tabla Hotel
        //public Hotel Hotel { get; set; }----------------------------------

        // Relación con la tabla Categoria
        public Categoria Categoria { get; set; }
    }
}
