using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly IDestinoQuery _query;

        public DestinoService(IDestinoQuery query)
        {
            _query = query;
        }

        public async Task<List<ResponseDestinoDto>> GetDestinos(string query)
        {
            return await _query.GetDestinos(query);
        }
    }
}
