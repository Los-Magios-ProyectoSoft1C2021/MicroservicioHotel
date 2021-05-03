using MicroservicioHotel.Domain.DTOs.Response;
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

        public CategoriaService(ICategoriaQuery query)
        {
            _query = query;
        }

        public Task<List<ResponseCategoriaDto>> GetAll()
        {
            return _query.GetAll();
        }
    }
}
