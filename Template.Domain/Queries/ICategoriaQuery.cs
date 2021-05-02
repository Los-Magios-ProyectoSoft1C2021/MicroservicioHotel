using MicroservicioHotel.Domain.DTOs.Response.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Domain.Queries
{
    public interface ICategoriaQuery
    {
        Task<List<ResponseGetAllCategoria>> GetAll();
    }
}
