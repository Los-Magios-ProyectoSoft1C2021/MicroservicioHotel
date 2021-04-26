using MicroservicioHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs
{
    public class HotelDto
    {
        public Guid HotelId { get; set; }
        public string Nombre { get; set; }
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


        // Relación con la tabla Habitacion
        public List<Habitacion> Habitaciones { get; set; }

        // Relación con la tabla FotoHotel
        public List<FotoHotel> FotosHotel { get; set; }
    }
}
