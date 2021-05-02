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

        public async Task<List<ResponseGetAllHabitacion>> GetAllHabitaciones(int hotelId)
        {
            var allhabitaciones = await _context.Habitacion
                .Where(h => h.HotelId == hotelId)
                .Select(m => new ResponseGetAllHabitacion
                {
                    HabitacionId  = m.HabitacionId,
                    Nombre  = m.Nombre,
                    HotelId  = m.HotelId,
                    Categoria  = m.Categoria.Nombre,
                }).ToListAsync();

            return allhabitaciones;
        }

        public async Task<ResponseGetHabitacionByIdDto> GetHabitacionById(int habitacionId, int hotelId)
        {
            var habitacion = await _context.Habitacion
                .Where(h => h.HabitacionId == habitacionId && h.HotelId == hotelId)
                .Select(a => new ResponseGetHabitacionByIdDto
                {
                    Nombre = a.Nombre,
                    HabitacionId = a.HabitacionId,
                    HotelId  = a.HotelId,
                    Categoria = a.Categoria.Nombre
                })
                .FirstOrDefaultAsync();

            return habitacion;
        }
        
        public async Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId)
        {
            var exists = await _context.Habitacion
                .AnyAsync(h => h.HabitacionId == habitacionId && h.HotelId == hotelId);

            return exists;
        }
    }
}
