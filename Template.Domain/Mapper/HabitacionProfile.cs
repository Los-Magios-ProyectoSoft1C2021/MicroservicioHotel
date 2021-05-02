using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.DTOs.Response.Habitacion;
using MicroservicioHotel.Domain.DTOs.Request.Habitacion;

namespace MicroservicioHotel.Domain.Mapper
{
    public class HabitacionProfile: Profile
    {
        public HabitacionProfile()
        {
            CreateMap<Habitacion, RequestCreateHabitacionDto>();
            CreateMap<RequestCreateHabitacionDto, Habitacion>();

            CreateMap<Habitacion, ResponseGetHabitacionByIdDto>()
                .ForMember(rh => rh.Categoria, m => m.MapFrom(h => h.Categoria.Nombre));
            CreateMap<ResponseGetHabitacionByIdDto, Habitacion>();

            CreateMap<Habitacion, RequestUpdateHabitacionDto>();
            CreateMap<RequestUpdateHabitacionDto, Habitacion>();

            CreateMap<Habitacion, ResponseUpdateHabitacion>()
                .ForMember(rh => rh.Categoria, m => m.MapFrom(h => h.Categoria.Nombre));
            CreateMap<ResponseUpdateHabitacion, Habitacion>();

            CreateMap<Habitacion, ResponseCreateHabitacion>()
                .ForMember(rh => rh.Categoria, m => m.MapFrom(h => h.Categoria.Nombre));
            CreateMap<ResponseCreateHabitacion, Habitacion>();

            CreateMap<ResponseGetHabitacionByIdDto, ResponseCreateHabitacion>();
            CreateMap<ResponseCreateHabitacion, ResponseGetHabitacionByIdDto>();
        }
    }
}
