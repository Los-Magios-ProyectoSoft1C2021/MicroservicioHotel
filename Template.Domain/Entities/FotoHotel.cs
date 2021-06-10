namespace MicroservicioHotel.Domain.Entities
{
    public class FotoHotel
    {
        public int FotoHotelId { get; set; }
        public int HotelId { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }

        public Hotel Hotel { get; set; }
    }
}
