using MicroservicioHotel.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHabitacionQuery
    {
        //Consultas.....
        Task<List<ResponseHabitacionDto>> GetAllHabitaciones(int hotelId, int categoriaId);
        Task<ResponseHabitacionDto> GetHabitacionById(int habitacionId, int hotelId);
        Task<ResponseHabitacionDto> GetHabitacionDataById(int habitacionId, int hotelId);
        Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId);
    }
}
