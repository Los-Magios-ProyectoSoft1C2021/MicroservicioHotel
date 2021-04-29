using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs
{
    public class ResponseGetAllHotelDto
    {
        public int HotelId { get; set; }
        public string Nombre { get; set; }
    }
}
