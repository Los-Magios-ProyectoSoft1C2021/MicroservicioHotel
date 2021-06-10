using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;

namespace MicroservicioHotel.Domain.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, RequestHotelDto>();
            CreateMap<RequestHotelDto, Hotel>();

            CreateMap<ResponseHotelDto, Hotel>();
            CreateMap<Hotel, ResponseHotelDto>();

            CreateMap<ResponseHotelSimpleDto, Hotel>();
            CreateMap<Hotel, ResponseHotelSimpleDto>();
        }
    }
}
