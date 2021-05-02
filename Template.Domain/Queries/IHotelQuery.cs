using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHotelQuery
    {
        Task<ResponseGetHotelByIdDto> GetById(int id);
        Task<List<ResponseGetAllHotelBy>> GetAllBy(int page, int estrellas, string ciudad);
        Task<List<ResponseGetAllHotelDto>> GetAll();
        Task<bool> CheckHotelExistsById(int id);
        Task<int> GetHotelsCount();
    }
}
