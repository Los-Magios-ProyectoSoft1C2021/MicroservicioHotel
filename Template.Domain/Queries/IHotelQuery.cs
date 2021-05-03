using MicroservicioHotel.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHotelQuery
    {
        Task<ResponseHotelDto> GetById(int id);
        Task<List<ResponseHotelDto>> GetAllBy(int page, int estrellas, string ciudad);
        Task<List<ResponseHotelDto>> GetAll();
        Task<bool> CheckHotelExistsById(int id);
        Task<int> GetHotelsCount();
    }
}
