using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs
{
    public class RequestCreateHabitacionDto
    {
        public int HabitacionId { get; set; }
        public int HotelId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
 
    }
}
