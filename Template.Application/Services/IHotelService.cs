using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface IHotelService
    {
        Task<ResponseHotelDto> Create(RequestHotelDto request);
        Task<ResponseHotelDto> Update(int id, RequestHotelDto request);
        Task<ResponseHotelDto> Patch(int id, JsonPatchDocument<RequestHotelDto> entityPatchDto);
        Task<List<ResponseHotelDto>> GetAll();
        Task<List<ResponseHotelDto>> GetAllBy(int page, int estrellas, string ciudad);
        Task<ResponseHotelDto> GetById(int id);
        Task<bool> CheckHotelExistsById(int id);
        Task<int> GetHotelsCount();
    }
}
