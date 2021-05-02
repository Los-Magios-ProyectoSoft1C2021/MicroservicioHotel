using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response.Hotel
{
    public class ResponseGetAllHotelsByPage
    {
        public List<ResponseGetAllHotelBy> Data { get; set; }
        public int ItemsCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string PreviousPage { set; get; }
        public string NextPage { get; set; }
    }

    public class ResponseGetAllHotelBy : ResponseHotelGeneric
    {
    }
}
