using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroservicioHotel.AccessData.Queries
{
    public class HotelQuery : IHotelQuery
    {
        private readonly HotelDbContext _context;

        public HotelQuery(HotelDbContext context)
        {
            _context = context;
        }

        public List<ResponseGetAllHotelDto> GetAll()
        {
            var hoteles = _context.Hoteles
                .Select(h => new ResponseGetAllHotelDto
                {
                    HotelId = h.HotelId,
                    Nombre = h.Nombre
                }).ToList();

            return hoteles;
        }

        public ResponseGetHotelByIdDto GetById(int id)
        {
            var hotel = _context.Hoteles
                .Select(h => new ResponseGetHotelByIdDto()
                { 
                    HotelId = id,
                    Nombre = h.Nombre,
                    Latitud = h.Latitud,
                    Longitud = h.Longitud,
                    Provincia = h.Provincia,
                    Ciudad = h.Ciudad,
                    Direccion = h.Direccion,
                    DireccionNum = h.DireccionNum,
                    DireccionObservaciones = h.DireccionObservaciones,
                    CodigoPostal = h.CodigoPostal,
                    Estrellas = h.Estrellas,
                    Telefono = h.Telefono,
                    Correo = h.Correo
                })
                .Where(h => h.HotelId == id)
                .FirstOrDefault();

            return hotel;
        }
    }
}
