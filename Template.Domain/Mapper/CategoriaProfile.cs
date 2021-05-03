using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Mapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, ResponseCategoriaDto>();
            CreateMap<ResponseCategoriaDto, Categoria>();
        }
    }
}
