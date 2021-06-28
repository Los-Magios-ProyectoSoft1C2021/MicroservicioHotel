using System.Collections.Generic;

namespace MicroservicioHotel.Domain.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public int EstrellasId { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string DireccionNum { get; set; }
        public string DireccionObservaciones { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }

        public Estrellas Estrellas { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public List<FotoHotel> FotosHotel { get; set; }
    }
}
