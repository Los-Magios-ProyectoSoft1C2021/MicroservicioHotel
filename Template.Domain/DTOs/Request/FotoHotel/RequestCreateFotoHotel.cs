using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Request.FotoHotel
{
    public class RequestCreateFotoHotel
    {
        public int HotelId { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
    }
}
