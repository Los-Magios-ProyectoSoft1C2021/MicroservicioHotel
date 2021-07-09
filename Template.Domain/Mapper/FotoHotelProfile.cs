using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;

namespace MicroservicioHotel.Domain.Mapper
{
    public class FotoHotelProfile : Profile
    {
        public FotoHotelProfile()
        {
            CreateMap<FotoHotel, ResponseFotoHotelDto>()
                .ReverseMap();

            CreateMap<RequestFotoHotelDto, FotoHotel>()
                .ReverseMap();
        }

    }
}
