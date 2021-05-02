using MicroservicioHotel.Domain.DTOs.Response.Categoria;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaQuery _query;

        public Task<List<ResponseGetAllCategoria>> GetAll()
        {
            return _query.GetAll();
        }
    }
}
