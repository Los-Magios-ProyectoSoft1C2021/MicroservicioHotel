using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Request.Habitacion
{
    public class RequestCreateHabitacionDto
    {
        public int HotelId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
    }
}
