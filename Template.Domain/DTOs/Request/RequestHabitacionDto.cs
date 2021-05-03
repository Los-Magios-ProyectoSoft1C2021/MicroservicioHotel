using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Request
{
    public class RequestHabitacionDto
    {
        public int HotelId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
    }
}
