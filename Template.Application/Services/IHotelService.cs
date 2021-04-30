using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Application.Services
{
    public interface IHotelService
    {
        void Create(RequestCreateHotelDto request);
        void Update(RequestUpdateHotelDto request);
        List<ResponseGetAllHotelDto> GetAll();
        List<ResponseGetAllHotelBy> GetAllBy(int page, int estrellas, string ciudad);
        ResponseGetHotelByIdDto GetById(int id);
    }
}
