using MicroservicioHotel.Domain.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IDestinoQuery
    {
        Task<List<ResponseDestinoDto>> GetDestinos(string query);
    }
}
