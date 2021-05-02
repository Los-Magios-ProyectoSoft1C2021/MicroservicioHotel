using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Request.FotoHotel;
using MicroservicioHotel.Domain.DTOs.Response.FotoHotel;
using MicroservicioHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Mapper
{
    public class FotoHotelProfile : Profile
    {
        public FotoHotelProfile()
        {
            CreateMap<FotoHotel, ResponseCreateFotoHotel>();
            CreateMap<ResponseCreateFotoHotel, FotoHotel>();    

            CreateMap<FotoHotel, ResponseGetAllFotoHotel>();
            CreateMap<ResponseGetAllFotoHotel, FotoHotel>();

            CreateMap<FotoHotel, RequestCreateFotoHotel>();
            CreateMap<RequestCreateFotoHotel, FotoHotel>();
        }
       
    }
}
