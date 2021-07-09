using MicroservicioHotel.Domain.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface ICategoriaQuery
    {
        Task<List<ResponseCategoriaDto>> GetAll();
        Task<bool> CheckIfExists(int categoriaId);
    }
}
