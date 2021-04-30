using AutoMapper;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, RequestCreateHotelDto>();
            CreateMap<RequestCreateHotelDto, Hotel>();

            CreateMap<Hotel, RequestUpdateHotelDto>();
            CreateMap<RequestUpdateHotelDto, Hotel>();

            CreateMap<Hotel, ResponseGetAllHotelDto>();
            CreateMap<ResponseGetAllHotelDto, Hotel>();

            CreateMap<Hotel, ResponseGetHotelByIdDto>();
            CreateMap<ResponseGetHotelByIdDto, Hotel>();
        }
    }
}
