using MicroservicioHotel.Domain.DTOs.Response.Habitacion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHabitacionQuery
    {
        //Consultas.....
        Task<List<ResponseGetAllHabitacion>> GetAllHabitaciones(int hotelId);
        Task<ResponseGetHabitacionByIdDto> GetHabitacionById(int habitacionId, int hotelId);
        Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId);
    }
}
