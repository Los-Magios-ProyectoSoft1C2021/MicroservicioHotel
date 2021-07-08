using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHotelQuery
    {
        Task<ResponseHotelDto> GetById(int id);
        Task<List<ResponseHotelSimpleDto>> GetAllBy(int page, int estrellas, string ciudad, int categoria, List<ResponseHabitacionesReservadasByHotelId> reservas);
        Task<List<ResponseHotelSimpleDto>> GetAll();
        Task<bool> CheckHotelExistsById(int id);
        Task<int> GetHotelsCount(int estrellas, string ciudad, int categoria, List<ResponseHabitacionesReservadasByHotelId> reservas);
    }
}
