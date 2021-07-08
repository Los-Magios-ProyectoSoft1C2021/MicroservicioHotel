using System.Collections.Generic;

namespace MicroservicioHotel.Domain.DTOs
{
    public class ResponseHabitacionesReservadasByHotelId
    {
        public int HotelId { get; set; }
        public List<int> Habitaciones { get; set; }
    }
}
