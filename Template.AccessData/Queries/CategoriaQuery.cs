using MicroservicioHotel.Domain.DTOs.Response.Categoria;
using MicroservicioHotel.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<ResponseGetAllCategoria>> GetAll()
        {
            var categorias = await _context.Categoria
                .Select(c => new ResponseGetAllCategoria
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
