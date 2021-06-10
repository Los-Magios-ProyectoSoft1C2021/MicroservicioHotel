namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponseFotoHotelDto
    {
        public int FotoHotelId { get; set; }
        public int HotelId { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
    }
}
