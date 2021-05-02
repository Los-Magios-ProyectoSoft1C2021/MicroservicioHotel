using AutoMapper;
using MicroservicioHotel.Domain.DTOs.Response.Categoria;
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
            CreateMap<Categoria, ResponseGetAllCategoria>();
            CreateMap<ResponseGetAllCategoria, Categoria>();
        }
    }
}
