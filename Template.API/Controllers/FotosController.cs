using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class FotosHotelController : ControllerBase
    {
        private readonly IFotosService _fotosService;
        private readonly IHotelService _hotelService;

        public FotosHotelController(IFotosService fotoService, IHotelService hotelService)
        {
            _fotosService = fotoService;
            _hotelService = hotelService;
        }

        /// <summary>
        /// Retorna todas las fotos de un hotel.
        /// </summary>
        /// <param name="hotelId">La ID del hotel.</param>
        /// <returns>Retorna todas las fotos de un hotel.</returns>
        /// <response code="200">Retorna todas las fotos del hotel</response>
        [AllowAnonymous]
        [HttpGet("{hotelId:int}/fotos")]
        public async Task<ActionResult<ResponseFotoHotelDto>> GetAllFotos(int hotelId)
        {
            var fotos = await _fotosService.GetAll(hotelId);
            return Ok(fotos);
        }

        /// <summary>
        /// Retorna la información de una única foto.
        /// </summary>
        /// <param name="fotoHotelId">La ID de la foto.</param>
        /// <param name="hotelId">La ID del hotel a la que pertenece la foto.</param>
        /// <returns>Retorna la información de la foto.</returns>
        /// <response code="200">Retorna la información de la foto</response>
        /// <response code="404">Si no se encuentra la foto</response>   
        [AllowAnonymous]
        [HttpGet("{hotelId:int}/fotos/{fotoHotelId:int}")]
        public async Task<ActionResult<ResponseFotoHotelDto>> GetFotoById(int fotoHotelId, int hotelId)
        {
            var foto = await _fotosService.GetById(fotoHotelId, hotelId);
            if (foto == null)
                return NotFound();

            return Ok(foto);
        }

        /// <summary>
        /// Sube una nueva foto al servidor.
        /// </summary>
        /// <remarks>
        /// Ejemplo de body:
        ///   {
        ///     "imagenUrl": "http://www.example.com/imagen.png"
        ///     "decripcion": "Foto de la habitación"
        ///   }
        /// </remarks>
        /// <param name="hotelId">La ID del hotel a la que se le quiere cargar la foto.</param>
        /// <param name="request">Body que contiene la información de la foto.</param>
        /// <returns>Sube una nueva foto al servidor.</returns>
        /// <response code="200">Retorna la información de la foto subida</response>
        /// <response code="400">Si no se encuentra el hotel al que se le quiere cargar la foto</response>  
        [Authorize(Policy = "AdminOnly")]
        [HttpPost("{hotelId:int}/fotos")]
        public async Task<ActionResult<ResponseFotoHotelDto>> PostFoto(int hotelId, RequestFotoHotelDto request)
        {
            var exists = await _hotelService.CheckIfExistsById(hotelId);
            if (!exists)
                return Problem(statusCode: 400, detail: "La ID del hotel ingresada no es válida");

            var createdFotoHotel = await _fotosService.Add(hotelId, request);
            if (createdFotoHotel == null)
                return Problem(statusCode: 500, detail: "Ha ocurrido un error al intentar guardar la foto");

            return Created(uri: $"{createdFotoHotel.HotelId}/fotos/{createdFotoHotel.FotoHotelId}", createdFotoHotel);
        }

    }
}