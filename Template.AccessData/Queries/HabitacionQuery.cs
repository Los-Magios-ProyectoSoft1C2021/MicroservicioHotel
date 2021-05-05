using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicroservicioHotel.Domain.DTOs.Response;

namespace MicroservicioHotel.AccessData.Queries
{
    public class HabitacionQuery : IHabitacionQuery
    {
        private readonly HotelDbContext _context;

        public HabitacionQuery(HotelDbContext context)
        {
            _context  = context;
        }

        public async Task<List<ResponseHabitacionDto>> GetAllHabitaciones(int hotelId, int categoriaId)
        {
            var habitaciones = await _context.Habitacion
                .Include(h => h.Categoria)
                .Where(h => (categoriaId > 0) ? h.CategoriaId == categoriaId : true)
                .Where(h => h.HotelId == hotelId)
                .Select(h => new ResponseHabitacionDto
                {
                    HabitacionId  = h.HabitacionId,
                    Nombre  = h.Nombre,
                    HotelId  = h.HotelId,
                    Categoria = new ResponseCategoriaDto
                    {
                        CategoriaId = h.CategoriaId,
                        Nombre = h.Categoria.Nombre,
                        Descripcion = h.Categoria.Descripcion
                    }
                })
                .ToListAsync();

            return habitaciones;
                
        }

        public async Task<ResponseHabitacionDto> GetHabitacionById(int habitacionId, int hotelId)
        {
            var habitacion = await _context.Habitacion
                .Where(h => h.HotelId == hotelId && h.HabitacionId == habitacionId)
                .Include(h => h.Categoria)
                .Select(h => new ResponseHabitacionDto
                {
                    Nombre = h.Nombre,
                    HabitacionId = h.HabitacionId,
                    HotelId  = h.HotelId,
                    Categoria = new ResponseCategoriaDto
                    {
                        CategoriaId = h.CategoriaId,
                        Nombre = h.Categoria.Nombre,
                        Descripcion = h.Categoria.Descripcion
                    }
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
