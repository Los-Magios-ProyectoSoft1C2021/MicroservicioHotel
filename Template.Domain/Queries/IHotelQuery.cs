using MicroservicioHotel.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHotelQuery
    {
        //Consultas
        ResponseGetHotelByIdDto GetById(int id);
        List<ResponseGetAllHotelDto> GetAll();
    }
}
