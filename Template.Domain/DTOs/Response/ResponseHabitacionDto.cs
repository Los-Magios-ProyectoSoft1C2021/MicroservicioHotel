namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponseHabitacionDto
    {
        public int HabitacionId { get; set; }
        public int HotelId { get; set; }
        public string Nombre { get; set; }
        public ResponseCategoriaDto Categoria { get; set; }
    }
}
