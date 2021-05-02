using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface IHotelService
    {
        Task<ResponseCreateHotel> Create(RequestCreateHotelDto request);
        Task<ResponseUpdateHotel> Update(int id, RequestUpdateHotelDto request);
        Task<List<ResponseGetAllHotelDto>> GetAll();
        Task<List<ResponseGetAllHotelBy>> GetAllBy(int page, int estrellas, string ciudad);
        Task<ResponseGetHotelByIdDto> GetById(int id);
        Task<bool> CheckHotelExistsById(int id);
    }
}
