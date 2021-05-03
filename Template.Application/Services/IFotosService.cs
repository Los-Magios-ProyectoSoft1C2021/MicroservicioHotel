using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface IFotosService
    {
        Task<ResponseFotoHotelDto> GetById(int fotoHotelId, int hotelId);
        Task<List<ResponseFotoHotelDto>> GetAll(int hotelId);
        Task<ResponseFotoHotelDto> Add(int hotelId, RequestFotoHotelDto request);
        Task Remove(int fotoHotelId, int hotelId);
        Task<bool> CheckFotoExistsById(int fotoHotelId, int hotelId);
    }
}
