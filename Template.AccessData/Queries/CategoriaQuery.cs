using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioHotel.AccessData.Queries
{
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly HotelDbContext _context;

        public CategoriaQuery(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseCategoriaDto>> GetAll()
        {
            var categorias = await _context.Categoria
                .Select(c => new ResponseCategoriaDto
                {
                    CategoriaId = c.CategoriaId,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion
                })
                .ToListAsync();

            return categorias;
        }
    }
}
