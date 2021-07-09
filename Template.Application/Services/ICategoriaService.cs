using MicroservicioHotel.Domain.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface ICategoriaService
    {
        Task<List<ResponseCategoriaDto>> GetAll();
        Task<bool> CheckIfExists(int categoriaId);
    }
}
