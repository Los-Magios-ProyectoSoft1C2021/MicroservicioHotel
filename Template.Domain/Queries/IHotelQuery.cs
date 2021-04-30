using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHotelQuery
    {
        //Consultas
        ResponseGetHotelByIdDto GetById(int id);
        List<ResponseGetAllHotelBy> GetAllBy(int page, int estrellas, string ciudad);
        List<ResponseGetAllHotelDto> GetAll();
    }
}
