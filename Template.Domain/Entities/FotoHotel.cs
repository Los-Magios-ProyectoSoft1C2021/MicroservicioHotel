using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Entities
{
    public class FotoHotel
    {
        public Guid FotoHotelId { get; set; }

        public Guid HotelId { get; set; }

        public string ImagenUrl { get; set; }

        public string Descripcion { get; set; }


        // Relación con la tabla Hotel
        public Hotel Hotel { get; set; }
    }
}
