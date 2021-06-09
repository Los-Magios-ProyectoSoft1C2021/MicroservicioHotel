using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.AccessData.Queries
{
    public class FotoHotelQuery : IFotoHotelQuery
    {
        private readonly HotelDbContext _context;

        public FotoHotelQuery(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckFotoHotelExistsById(int fotoHotelId, int hotelId)
        {
            var exists = await _context.FotoHotel
                .AnyAsync(fh => fh.FotoHotelId == fotoHotelId && fh.HotelId == hotelId);

            return exists;
        }

        public async Task<List<ResponseFotoHotelDto>> GetAll(int hotelId)
        {
            var fotos = await _context.FotoHotel
                .Where(fh => fh.HotelId == hotelId)
                .Select(fh => new ResponseFotoHotelDto
                {
                    FotoHotelId = fh.FotoHotelId,
                    HotelId = fh.HotelId,
                    ImagenUrl = fh.ImagenUrl,
                    Descripcion = fh.Descripcion
                })
                .ToListAsync();

            return fotos;
        }

        
        public async Task<ResponseFotoHotelDto> GetById(int fotoHotelId, int hotelId)
        {
            var foto = await _context.FotoHotel
                .Where(fh => fh.FotoHotelId == fotoHotelId && fh.HotelId == hotelId)
                .Select(fh => new ResponseFotoHotelDto
                { 
                    FotoHotelId = fh.FotoHotelId,
                    HotelId = fh.HotelId,
                    ImagenUrl = fh.ImagenUrl,
                    Descripcion = fh.Descripcion
                })
                .FirstOrDefaultAsync();

            return foto;
        }
        
    }
}
