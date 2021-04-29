using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MicroservicioHotel.AccessData.Queries
{
    public class HabitacionQuery : IHabitacionQuery
    {
        private readonly HotelDbContext _context;

        public HabitacionQuery(HotelDbContext context)
        {
            _context  = context;
        }

        public List<ResponseGetHabitacionByIdDto> GetAllHabitacion()
        {
            var allhabitaciones = _context.Habitaciones
                 .Select(m => new ResponseGetHabitacionByIdDto
                 {
                     HabitacionId  = m.HabitacionId,
                     Nombre  = m.Nombre,
                     HotelId  = m.HotelId,
                     Categoria  = m.Categoria.Descripcion,
                 }).ToList();

            return allhabitaciones;
        }

        public ResponseGetHabitacionByIdDto GetIdHabitacion(int id)
        {
            var habitacion = _context.Habitaciones
                .Select(a => new ResponseGetHabitacionByIdDto()
                {
                    Nombre = a.Nombre,
                    HabitacionId = id,
                    HotelId  = a.HotelId,
                    Categoria = a.Categoria.Descripcion,

                })
                .Where(a  => a.HabitacionId  == id)
                .FirstOrDefault();

            return habitacion;
                    
        }
    }
}
