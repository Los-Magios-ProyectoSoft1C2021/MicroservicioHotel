using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/busqueda")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly IDestinoService _service;

        public DestinoController(IDestinoService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResponseDestinoDto>>> GetDestinos([FromQuery] string query)
        {
            if (query.Length == 0)
                return Problem(detail: "La query no puede estar vacía", statusCode: 404);

            var destinos = await _service.GetDestinos(query);
            return Ok(destinos);
        }
    }
}
