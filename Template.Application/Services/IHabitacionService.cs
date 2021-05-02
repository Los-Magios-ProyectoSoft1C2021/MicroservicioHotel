using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroservicioHotel.Domain.DTOs.Request.Habitacion;
using MicroservicioHotel.Domain.DTOs.Response.Habitacion;

namespace MicroservicioHotel.Application.Services
{
    public interface IHabitacionService
    {
        Task<ResponseCreateHabitacion> Create(RequestCreateHabitacionDto request);
        Task<ResponseUpdateHabitacion> Update(int habitacionid, int hotelId, RequestUpdateHabitacionDto request);
        Task<ResponseGetHabitacionByIdDto> GetHabitacionById(int habitacionId, int hotelId);
        Task<List<ResponseGetAllHabitacion>> GetAllHabitaciones(int hotelId);
        Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId);
    }
}
