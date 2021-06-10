using System.Collections.Generic;

namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponsePageHotels
    {
        public List<ResponseHotelSimpleDto> Data { get; set; }
        public int ItemsCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }
    }
}
