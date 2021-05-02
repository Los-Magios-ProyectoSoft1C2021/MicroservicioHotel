using MicroservicioHotel.Domain.DTOs.Response.FotoHotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IFotoHotelQuery
    {
        Task<List<ResponseGetAllFotoHotel>> GetAll(int hotelId);
        Task<ResponseGetFotoHotelById> GetById(int fotoHotelId, int hotelId);
        Task<bool> CheckFotoHotelExistsById(int fotoHotelId, int hotelId);
    }
}
