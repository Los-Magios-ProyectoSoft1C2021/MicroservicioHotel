using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/hotel/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        /// <summary>
        /// Retorna todas las categorías de habitaciones disponibles.
        /// </summary>
        /// <returns>Todas las categorías de habitaciones.</returns>
        /// <response code="200">Retorna todas las categorías</response> 
        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<ResponseCategoriaDto>> GetAll()
        {
            var categorias = await _categoriaService.GetAll();
            return categorias;
        }
    }
}
