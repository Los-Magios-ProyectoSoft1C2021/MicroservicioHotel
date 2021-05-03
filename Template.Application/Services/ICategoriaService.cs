using MicroservicioHotel.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public interface ICategoriaService
    {
        Task<List<ResponseCategoriaDto>> GetAll();
    }
}
