using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Queries;
using System.Collections.Generic;
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

        public async Task<List<ResponseCategoriaDto>> GetAll()
        {
            return await _query.GetAll();
        }

        public async Task<bool> CheckIfExists(int categoriaId)
        {
            return await _query.CheckIfExists(categoriaId);
        }
    }
}
