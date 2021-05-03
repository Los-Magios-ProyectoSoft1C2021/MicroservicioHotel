using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.DTOs.Request;

namespace MicroservicioHotel.Domain.Mapper
{
    public class HabitacionProfile: Profile
    {
        public HabitacionProfile()
        {
            CreateMap<Habitacion, RequestHabitacionDto>();
            CreateMap<RequestHabitacionDto, Habitacion>();

            CreateMap<Habitacion, ResponseHabitacionDto>()
                .ForMember(rh => rh.Categoria, m => m.MapFrom(h => h.Categoria.Nombre));
            CreateMap<ResponseHabitacionDto, Habitacion>();
        }
    }
}
