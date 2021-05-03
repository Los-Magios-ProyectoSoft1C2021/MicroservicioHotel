using MicroservicioHotel.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface ICategoriaQuery
    {
        Task<List<ResponseCategoriaDto>> GetAll();
    }
}
