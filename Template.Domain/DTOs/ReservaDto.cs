using MicroservicioHotel.Domain.Entities;
using System;

namespace MicroservicioHotel.Domain.DTOs
{
    public class ReservaDto
    {
        public Guid ReservaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid HabitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Relación con la tabla Habitacion
        public Habitacion Habitacion { get; set; }
    }
}
