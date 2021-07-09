using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface IHabitacionService
    {
        Task<ResponseHabitacionDto> Create(int hotelId, RequestHabitacionDto request);
        Task<ResponseHabitacionDto> Update(int habitacionid, int hotelId, RequestHabitacionDto request);
        Task<ResponseHabitacionDto> Patch(int habitacionId, int hotelId, JsonPatchDocument<RequestHabitacionDto> entityPatchDto);
        Task<ResponseHabitacionDto> GetHabitacionById(int habitacionId, int hotelId);
        Task<List<ResponseHabitacionDto>> GetAllHabitaciones(int hotelId, int categoriaId);
        Task<bool> CheckIfExistsById(int habitacionId, int hotelId);
    }
}
