using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/Hotel/Habitacion/Categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<List<ResponseCategoriaDto>> GetAll()
        {
            var categorias = await _categoriaService.GetAll();
            return categorias;
        }
    }
}
