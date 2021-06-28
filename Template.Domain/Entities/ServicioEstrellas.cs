using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Entities
{
    public class ServicioEstrellas
    {
        public int ServicioEstrellaId { get; set; }
        public int ServicioId { get; set; }
        public int EstrellasId { get; set; }
        
        public Servicio Servicio { get; set; }
        public Estrellas Estrellas { get; set; }
    }
}
