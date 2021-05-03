﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponsePageHotels
    {
        public List<ResponseHotelDto> Data { get; set; }
        public int ItemsCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }
    }
}