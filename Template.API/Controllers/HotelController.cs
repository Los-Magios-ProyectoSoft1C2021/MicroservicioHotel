using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IConfiguration _configuration;

        public HotelController(IHotelService hotelService, IConfiguration configuration)
        {
            _hotelService = hotelService;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna la información de un hotel según su ID.
        /// </summary>
        /// <param name="id">La ID del hotel.</param>
        /// <returns>Retorna un hotel.</returns>
        /// <response code="200">Retorna la información del hotel</response>
        /// <response code="404">Si no se encuentra el hotel</response>  
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseHotelDto>> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        /// <summary>
        /// Retorna una página de hoteles según el número de página, estrellas y ciudad.
        /// </summary>
        /// <param name="page">Número de página.</param>
        /// <param name="estrellas">Estrellas del hotel.</param>
        /// <param name="ciudad">Ciudad en donde está ubicado el hotel.</param>
        /// <param name="fechaInicio">Fecha de inicio de la reserva que se busca.</param>
        /// <param name="categoria">Categoría de la habitación que se está buscando.</param>
        /// <param name="fechaFin">Fecha de fin de la reserva que se busca.</param>
        /// <returns>Retorna un conjunto de hoteles.</returns>
        /// <response code="200">Retorna la información de los hoteles</response>
        /// <response code="400">Si no se encuentra el hotel</response>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ResponsePageHotelsDto>> GetHotelBy(
            [FromQuery(Name = "page")] int page,
            [FromQuery(Name = "estrellas")] int estrellas,
            [FromQuery(Name = "ciudad")] string ciudad,
            [FromQuery(Name = "categoria")] int categoria,
            [FromQuery(Name = "fechaInicio")] DateTime fechaInicio,
            [FromQuery(Name = "fechaFin")] DateTime fechaFin)
        {
            if (page == 0)
                page = 1;
            else if (page < 0)
                return BadRequest();

            if (estrellas < 0 || estrellas > 5)
                return BadRequest();

            var hoteles = await _hotelService.GetAllBy(page, estrellas, ciudad, categoria, fechaInicio, fechaFin);

            int pageSize = int.Parse(_configuration.GetSection("PageSize").Value);
            int hotelesCount = await _hotelService.GetHotelsCount(estrellas, ciudad, categoria, fechaInicio, fechaFin);
            int pageCount = (hotelesCount / pageSize) + 1;

            var response = new ResponsePageHotelsDto
            {
                Data = hoteles,
                ItemsCount = hoteles.Count,
                PageCount = pageCount,
                CurrentPage = page
            };

            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo hotel.
        /// </summary>
        /// <remarks>
        /// Ejemplo de body:
        ///   {
        ///     "nombre": "Hotel Manuel Belgrano"
        ///     "Longitud": 2.123132,
        ///     "Latitud": 1.123123,
        ///     "Provincia": "Buenos Aires",
        ///     "Ciudad": "Quilmes",
        ///     "Direccion": "Lavalle",
        ///     "DireccionNum": "123",
        ///     "DireccionObservaciones": "",
        ///     "CodigoPostal": "123",
        ///     "Estrellas": 4,
        ///     "Telefono": "1126453245",
        ///     "Correo": "hotellavalle@hotmail.com" 
        ///   }
        /// </remarks>
        /// <param name="hotel">Body que contiene los datos del hotel a crear.</param>
        /// <returns>El hotel creado.</returns>
        /// <response code="201">Retorna la información del hotel creado</response>
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult> PostHotel(RequestHotelDto hotel)
        {
            var createdHotel = await _hotelService.Create(hotel);
            if (createdHotel == null)
                throw new Exception();

            return Created(uri: $"api/hotel/{createdHotel.HotelId}", createdHotel);
        }

        /// <summary>
        /// Modifica los datos de un hotel ya existente.
        /// </summary>
        /// <remarks>
        /// Ejemplo de body:
        ///   {
        ///     "nombre": "Hotel San Martín"
        ///     "Longitud": 2.123132,
        ///     "Latitud": 1.123123,
        ///     "Provincia": "Buenos Aires",
        ///     "Ciudad": "Quilmes",
        ///     "Direccion": "San Martín",
        ///     "DireccionNum": "123",
        ///     "DireccionObservaciones": "",
        ///     "CodigoPostal": "123",
        ///     "Estrellas": 4,
        ///     "Telefono": "1126453245",
        ///     "Correo": "hotellavalle@hotmail.com" 
        ///   }
        /// </remarks>
        /// <param name="id">El ID del hotel a modificar.</param>
        /// <param name="hotel">Body que contiene los datos del hotel a modificar.</param>
        /// <returns>El hotel modificado.</returns>
        /// <response code="200">Retorna la información del hotel modificado</response>
        /// <response code="204">Si no se encuentra el hotel a modificar</response>
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseHotelDto>> PutHotel(int id, RequestHotelDto hotel)
        {
            var exists = await _hotelService.CheckIfExistsById(id);
            if (!exists)
                return StatusCode(204, null); // 204: Recurso no encontrado

            var updatedHotel = await _hotelService.Update(id, hotel);
            if (updatedHotel == null)
                throw new Exception();

            return Ok(updatedHotel);
        }

        /// <summary>
        /// Modifica los datos de un hotel ya existente.
        /// </summary>
        /// <remarks>
        /// Ejemplo de body:
        ///     [
        ///         {
        ///             "value": "Hotel Primavera",
        ///             "path": "/Nombre",
        ///             "op": "replace"
        ///         }
        ///     ]
        /// </remarks>
        /// <param name="id">La ID del hotel que se quiere modificar.</param>
        /// <param name="entityPatchDto">Body que contiene todas las operaciones de transformación que se le van a aplicar al hotel.</param>
        /// <returns>Retorna el hotel modificado.</returns>
        /// <response code="200">Retorna la información del hotel modificado</response>
        /// <response code="204">Si no se encuentra el hotel a modificar</response>  
        [Authorize(Policy = "AdminOnly")]
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ResponseHotelDto>> PatchHotel(int id, [FromBody] JsonPatchDocument<RequestHotelDto> entityPatchDto)
        {
            var exists = await _hotelService.CheckIfExistsById(id);
            if (!exists)
                return NotFound();

            var modifiedHotel = await _hotelService.Patch(id, entityPatchDto);
            return Ok(modifiedHotel);
        }

    }
}
