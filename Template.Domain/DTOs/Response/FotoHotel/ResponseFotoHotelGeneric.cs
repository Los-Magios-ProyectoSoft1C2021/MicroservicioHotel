using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response.FotoHotel
{
    public class ResponseFotoHotelGeneric
    {
        public int FotoHotelId { get; set; }
        public int HotelId { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
    }
}
