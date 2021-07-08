using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ResponseHotelSimpleDto>> GetAll()
        {
            var hoteles = await _context.Hotel
                .Select(h => new ResponseHotelSimpleDto
                {
                    HotelId = h.HotelId,
                    Nombre = h.Nombre,
                    Provincia = h.Provincia,
                    Ciudad = h.Ciudad,
                    Direccion = h.Direccion,
                    DireccionNum = h.DireccionNum,
                    Estrellas = h.EstrellasId,
                    Foto = h.FotosHotel.FirstOrDefault().ImagenUrl,
                    Telefono = h.Telefono
                }).ToListAsync();

            return hoteles;
        }

        public async Task<List<ResponseHotelSimpleDto>> GetAllBy(int page, int estrellas, string ciudad, int categoria, List<ResponseHabitacionesReservadasByHotelId> reservas)
        {
            var dictionaryReservas = new Dictionary<int, List<int>>();
            if (reservas != null)
            {
                foreach (var reserva in reservas)
                {
                    dictionaryReservas[reserva.HotelId] = reserva.Habitaciones;
                }
            }

            int skip = 0;
            var resultsSkip = new List<int>();
            while (resultsSkip.Count < (page - 1) * _pageSize)
            {
                var hoteles = await _context.Hotel
                    .Where(h => estrellas <= 0 || h.EstrellasId == estrellas)
                    .Where(h => ciudad == null || h.Ciudad == ciudad)
                    .OrderBy(h => h.HotelId)
                    .Select(h => h.HotelId)
                    .Skip(skip)
                    .Take(_pageSize * (page - 1) - resultsSkip.Count)
                    .ToListAsync();

                if (hoteles.Count == 0)
                    break;

                skip += hoteles.Count;

                foreach (var hotel in hoteles)
                {
                    bool add = await _context.Habitacion
                        .Where(x => x.HotelId == hotel)
                        .Where(x => (dictionaryReservas.ContainsKey(hotel)) ? !dictionaryReservas[hotel].Contains(x.HabitacionId) : true)
                        .AnyAsync(x => (categoria <= 0 || x.CategoriaId == categoria));

                    if (add)
                        resultsSkip.Add(hotel);
                }
            }

            var resultHoteles = new List<ResponseHotelSimpleDto>();
            while (resultHoteles.Count < _pageSize)
            {
                var hoteles = await _context.Hotel
                    .Where(h => estrellas <= 0 || h.EstrellasId == estrellas)
                    .Where(h => ciudad == null || h.Ciudad == ciudad)
                    .OrderBy(h => h.HotelId)
                    .Select(h => new ResponseHotelSimpleDto
                    {
                        HotelId = h.HotelId,
                        Nombre = h.Nombre,
                        Provincia = h.Provincia,
                        Ciudad = h.Ciudad,
                        Direccion = h.Direccion,
                        DireccionNum = h.DireccionNum,
                        Estrellas = h.EstrellasId,
                        Foto = h.FotosHotel.FirstOrDefault().ImagenUrl,
                        Telefono = h.Telefono
                    })
                    .Skip(skip)
                    .Take(_pageSize - resultHoteles.Count)
                    .ToListAsync();

                if (hoteles.Count == 0)
                    break;

                skip += hoteles.Count;

                foreach (var hotel in hoteles)
                {
                    bool add = await _context.Habitacion
                        .Where(x => x.HotelId == hotel.HotelId)
                        .Where(x => (dictionaryReservas.ContainsKey(hotel.HotelId)) ? !dictionaryReservas[hotel.HotelId].Contains(x.HabitacionId) : true)
                        .AnyAsync(x => (categoria <= 0 || x.CategoriaId == categoria));

                    if (add)
                        resultHoteles.Add(hotel);
                }
            }

            return resultHoteles;
        }

        public async Task<ResponseHotelDto> GetById(int id)
        {
            var hotel = await _context.Hotel
                .Select(h => new ResponseHotelDto()
                {
                    HotelId = id,
                    Nombre = h.Nombre,
                    Provincia = h.Provincia,
                    Ciudad = h.Ciudad,
                    Direccion = h.Direccion,
                    DireccionNum = h.DireccionNum,
                    DireccionObservaciones = h.DireccionObservaciones,
                    CodigoPostal = h.CodigoPostal,
                    Estrellas = h.EstrellasId,
                    Telefono = h.Telefono,
                    Correo = h.Correo,
                    Latitud = h.Latitud,
                    Longitud = h.Longitud,
                    Fotos = h.FotosHotel.Select(fh => new ResponseFotoHotelDto
                    {
                        ImagenUrl = fh.ImagenUrl,
                        Descripcion = fh.Descripcion
                    }).ToList(),
                    Servicios = h.Estrellas.Servicios.Select(se => se.Servicio.Descripcion).ToList()
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

        public async Task<int> GetHotelsCount(int estrellas, string ciudad, int categoria, List<ResponseHabitacionesReservadasByHotelId> reservas)
        {
            var dictionaryReservas = new Dictionary<int, List<int>>();
            if (reservas != null)
            {
                foreach (var reserva in reservas)
                {
                    dictionaryReservas[reserva.HotelId] = reserva.Habitaciones;
                }
            }

            var hoteles = await _context.Hotel
                .Where(h => estrellas <= 0 || h.EstrellasId == estrellas)
                .Where(h => ciudad == null || h.Ciudad == ciudad)
                .OrderBy(h => h.HotelId)
                .Select(h => h.HotelId)
                .ToListAsync();

            int count = 0;
            foreach (var hotel in hoteles)
            {
                bool add = await _context.Habitacion
                    .Where(x => x.HotelId == hotel)
                    .Where(x => (dictionaryReservas.ContainsKey(hotel)) ? !dictionaryReservas[hotel].Contains(x.HabitacionId) : true)
                    .AnyAsync(x => (categoria <= 0 || x.CategoriaId == categoria));

                if (add)
                    count += 1;
            }

            return count;
        }
    }
}
