using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.Entities;

namespace MicroservicioHotel.Domain.Mapper
{
    public class HabitacionProfile: Profile
    {
        public HabitacionProfile()
        {
            CreateMap<Habitacion, RequestCreateHabitacionDto>();
            CreateMap<RequestCreateHabitacionDto, Habitacion>();

            CreateMap<Habitacion, ResponseGetHabitacionByIdDto>();
            CreateMap<ResponseGetHabitacionByIdDto, Habitacion>();

        }
    }
}
