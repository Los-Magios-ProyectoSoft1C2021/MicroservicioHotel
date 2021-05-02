using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.AccessData.Queries
{
    public class HotelQuery : IHotelQuery
    {
        private readonly HotelDbContext _context;
        private readonly int _pageSize;

        public HotelQuery(HotelDbContext context, IConfiguration configuration)
        {
            _context = context;
            _pageSize = int.Parse(configuration.GetSection("PageSize").Value);
        }

        public async Task<List<ResponseGetAllHotelDto>> GetAll()
        {
            var hoteles = await _context.Hotel
                .Select(h => new ResponseGetAllHotelDto
                {
                    HotelId = h.HotelId,
                    Nombre = h.Nombre,
                    Provincia = h.Provincia,
                    Ciudad = h.Ciudad,
                    Direccion = h.Direccion,
                    DireccionNum = h.DireccionNum,
                    DireccionObservaciones= h.DireccionObservaciones,
                    CodigoPostal= h.CodigoPostal,
                    Estrellas= h.Estrellas,
                    Telefono=h.Telefono,
                    Correo= h.Correo,
                    Latitud = h.Latitud,
                    Longitud =  h.Longitud,
                    Fotos = h.FotosHotel.Select(fh => new ResponseHotelGenericFotoHotel
                    {
                        ImagenUrl = fh.ImagenUrl,
                        Descripcion = fh.Descripcion
                    }).ToList()
                }).ToListAsync();

            return hoteles;
        }

        public async Task<List<ResponseGetAllHotelBy>> GetAllBy(int page, int estrellas, string ciudad)
        {
            var query = _context.Hotel;

            if (estrellas > 0)
                query.Where(h => h.Estrellas == estrellas);

            if (ciudad != null)
                query.Where(h => h.Ciudad == ciudad);

            return await query.Select(h => new ResponseGetAllHotelBy
            {
                HotelId = h.HotelId,
                Nombre = h.Nombre,
                Provincia = h.Provincia,
                Ciudad = h.Ciudad,
                Direccion = h.Direccion,
                DireccionNum = h.DireccionNum,
                DireccionObservaciones = h.DireccionObservaciones,
                CodigoPostal = h.CodigoPostal,
                Estrellas = h.Estrellas,
                Telefono = h.Telefono,
                Correo = h.Correo,
                Latitud = h.Latitud,
                Longitud = h.Longitud,
                Fotos = h.FotosHotel.Select(fh => new ResponseHotelGenericFotoHotel
                {
                    ImagenUrl = fh.ImagenUrl,
                    Descripcion = fh.Descripcion
                }).ToList()
            })
                .Skip((page - 1) * _pageSize)
                .Take(_pageSize)
                .ToListAsync();
        }

        public async Task<ResponseGetHotelByIdDto> GetById(int id)
        {
            var hotel = await _context.Hotel
                .Select(h => new ResponseGetHotelByIdDto()
                { 
                    HotelId = id,
                    Nombre = h.Nombre,
                    Provincia = h.Provincia,
                    Ciudad = h.Ciudad,
                    Direccion = h.Direccion,
                    DireccionNum = h.DireccionNum,
                    DireccionObservaciones = h.DireccionObservaciones,
                    CodigoPostal = h.CodigoPostal,
                    Estrellas = h.Estrellas,
                    Telefono = h.Telefono,
                    Correo = h.Correo,
                    Latitud = h.Latitud,
                    Longitud = h.Longitud,
                    Fotos = h.FotosHotel.Select(fh => new ResponseHotelGenericFotoHotel
                    {
                        ImagenUrl = fh.ImagenUrl,
                        Descripcion = fh.Descripcion
                    }).ToList()
                })
                .Where(h => h.HotelId == id)
                .FirstOrDefaultAsync();

            return hotel;
        }

        public async Task<bool> CheckHotelExistsById(int id)
        {
            var exists = await _context.Hotel
                .AnyAsync(h => h.HotelId == id);

            return exists;
        }

        public async Task<int> GetHotelsCount()
        {
            return await _context.Hotel.CountAsync();
        }
    }
}
