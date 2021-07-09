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
            CreateMap<RequestHotelDto, Hotel>()
                .ForMember(m => m.EstrellasId, mapper => mapper.MapFrom(x => x.Estrellas))
                .ForMember(m => m.Estrellas, mapper => mapper.Ignore())
                .ReverseMap();

            CreateMap<Hotel, ResponseHotelDto>()
                .ReverseMap();

            CreateMap<Hotel, ResponseHotelSimpleDto>()
                .ReverseMap();
        }
    }
}
