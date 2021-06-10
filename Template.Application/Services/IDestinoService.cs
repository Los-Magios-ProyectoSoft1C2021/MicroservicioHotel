using MicroservicioHotel.Domain.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface IDestinoService
    {
        Task<List<ResponseDestinoDto>> GetDestinos(string query);
    }
}
