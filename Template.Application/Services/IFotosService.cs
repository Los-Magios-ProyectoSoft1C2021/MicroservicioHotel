using MicroservicioHotel.Domain.DTOs.Request.FotoHotel;
using MicroservicioHotel.Domain.DTOs.Response.FotoHotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface IFotosService
    {
        Task<ResponseGetFotoHotelById> GetById(int fotoHotelId, int hotelId);
        Task<List<ResponseGetAllFotoHotel>> GetAll(int hotelId);
        Task<ResponseCreateFotoHotel> Add(RequestCreateFotoHotel request);
        Task Remove(int fotoHotelId, int hotelId);
        Task<bool> CheckFotoExistsById(int fotoHotelId, int hotelId);
    }
}
