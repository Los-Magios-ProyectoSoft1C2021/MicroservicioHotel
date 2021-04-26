using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Entities
{
    public class FotoHotel
    {
        public Guid FotoHotelId { get; set; }
        public Guid HotelId { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }

        public Hotel Hotel { get; set; }
    }
}
