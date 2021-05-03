using MicroservicioHotel.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IFotoHotelQuery
    {
        Task<List<ResponseFotoHotelDto>> GetAll(int hotelId);
        Task<ResponseFotoHotelDto> GetById(int fotoHotelId, int hotelId);
        Task<bool> CheckFotoHotelExistsById(int fotoHotelId, int hotelId);
    }
}
