using MicroservicioHotel.AccessData;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DestinoQuery : IDestinoQuery
{
    private readonly HotelDbContext _context;

    public DestinoQuery(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<ResponseDestinoDto>> GetDestinos(string query)
    {
        var destinos = await _context.Hotel
             .Where(h => h.Ciudad.Contains(query) || h.Provincia.Contains(query))
             .Select(h => new ResponseDestinoDto
             {
                 Ciudad = h.Ciudad,
                 Provincia = h.Provincia
             })
             .Distinct()
             .ToListAsync();

        return destinos;
    }
}