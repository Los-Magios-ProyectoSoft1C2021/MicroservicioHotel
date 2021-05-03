using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;

namespace MicroservicioHotel.Application.Services
{
    public interface IHabitacionService
    {
        Task<ResponseHabitacionDto> Create(RequestHabitacionDto request);
        Task<ResponseHabitacionDto> Update(int habitacionid, int hotelId, RequestHabitacionDto request);
        Task<ResponseHabitacionDto> GetHabitacionById(int habitacionId, int hotelId);
        Task<List<ResponseHabitacionDto>> GetAllHabitaciones(int hotelId);
        Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId);
    }
}
