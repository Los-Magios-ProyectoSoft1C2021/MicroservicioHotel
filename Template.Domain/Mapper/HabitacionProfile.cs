using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;

namespace MicroservicioHotel.Domain.Mapper
{
    public class HabitacionProfile : Profile
    {
        public HabitacionProfile()
        {
            CreateMap<Habitacion, RequestHabitacionDto>();
            CreateMap<RequestHabitacionDto, Habitacion>();

            CreateMap<Habitacion, ResponseHabitacionDto>()
                .ForMember(rh => rh.Categoria, m => m.MapFrom(h => new ResponseCategoriaDto
                {
                    CategoriaId = h.Categoria.CategoriaId,
                    Nombre = h.Categoria.Nombre,
                    Descripcion = h.Categoria.Descripcion
                }));
            CreateMap<ResponseHabitacionDto, Habitacion>();
        }
    }
}
