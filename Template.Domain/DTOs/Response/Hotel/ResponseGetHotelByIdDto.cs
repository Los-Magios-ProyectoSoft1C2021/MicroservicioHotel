using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response.Hotel
{
    public class ResponseGetHotelByIdDto : ResponseHotelGeneric
    {
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string DireccionNum { get; set; }
        public string DireccionObservaciones { get; set; }
        public string CodigoPostal { get; set; }
        public int Estrellas { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
