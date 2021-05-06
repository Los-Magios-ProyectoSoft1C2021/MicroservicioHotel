using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponseHotelSimpleDto
    {
        public int HotelId { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string DireccionNum { get; set; }
        public int Estrellas { get; set; }
        
        public List<ResponseFotoHotelDto> Fotos { get; set; }
    }
}
