using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;

namespace MicroservicioHotel.Domain.Mapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, ResponseCategoriaDto>()
                .ReverseMap();
        }
    }
}
