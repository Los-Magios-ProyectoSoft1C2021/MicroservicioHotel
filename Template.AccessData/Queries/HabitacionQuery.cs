using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicroservicioHotel.Domain.DTOs.Response.Habitacion;

namespace MicroservicioHotel.AccessData.Queries
{
    public class HabitacionQuery : IHabitacionQuery
    {
        private readonly HotelDbContext _context;

        public HabitacionQuery(HotelDbContext context)
        {
            _context  = context;
        }

        public async Task<List<ResponseGetHabitacionByIdDto>> GetAllHabitaciones(int hotelId)
        {
            var allhabitaciones = await _context.Habitaciones
                .Where(h => h.HotelId == hotelId)
                .Select(m => new ResponseGetHabitacionByIdDto
                {
                    HabitacionId  = m.HabitacionId,
                    Nombre  = m.Nombre,
                    HotelId  = m.HotelId,
                    Categoria  = m.Categoria.Descripcion,
                }).ToListAsync();

            return allhabitaciones;
        }

        public async Task<ResponseGetHabitacionByIdDto> GetHabitacionById(int habitacionId, int hotelId)
        {
            var habitacion = await _context.Habitaciones
                .Where(h => h.HabitacionId == habitacionId && h.HotelId == hotelId)
                .Select(a => new ResponseGetHabitacionByIdDto
                {
                    Nombre = a.Nombre,
                    HabitacionId = a.HabitacionId,
                    HotelId  = a.HotelId,
                    Categoria = a.Categoria.Descripcion,

                })
                .FirstOrDefaultAsync();

            return habitacion;
        }
        
        public async Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId)
        {
            var exists = await _context.Habitaciones
                .AnyAsync(h => h.HabitacionId == habitacionId && h.HotelId == hotelId);

            return exists;
        }
    }
}
