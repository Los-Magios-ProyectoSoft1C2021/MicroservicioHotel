using MicroservicioHotel.Domain.DTOs;
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
        ResponseGetHotelByIdDto GetById(int id);
    }
}
