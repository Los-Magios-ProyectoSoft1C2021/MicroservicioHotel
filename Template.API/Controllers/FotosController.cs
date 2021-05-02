using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Request.FotoHotel;
using MicroservicioHotel.Domain.DTOs.Request.Habitacion;
using MicroservicioHotel.Domain.DTOs.Response.FotoHotel;
using MicroservicioHotel.Domain.DTOs.Response.Habitacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/Hotel")]
    [ApiController]
    public class FotosHotelController : ControllerBase
    {
        private readonly IFotosService _fotoService;
        private readonly IHotelService _hotelService;

        public FotosHotelController(IFotosService fotoService, IHotelService hotelService)
        {
            _fotoService = fotoService;
            _hotelService = hotelService;
        }

        [HttpGet("{hotelId}/Fotos/{fotoHotelId}")]
        public async Task<ActionResult<ResponseGetFotoHotelById>> GetFotoById(int fotoHotelId, int hotelId)
        {
            try
            {
                var fotoh = await _fotoService.GetById(fotoHotelId, hotelId);
                if (fotoh == null)
                    return NotFound();

                return Ok(fotoh);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }

        }

        [HttpPost("{hotelId}/Fotos")]
        public async Task<ActionResult<ResponseCreateFotoHotel>> PostFoto(int hotelId, RequestCreateFotoHotel request)
        {
            try
            {
                var createdFotoHotel = await _fotoService.Add(request);
                if (createdFotoHotel == null)
                    throw new Exception();

                return Created(uri: $"{createdFotoHotel.HotelId}/Fotos/{createdFotoHotel.FotoHotelId}", createdFotoHotel);
            }
            catch
            {
                return StatusCode(500, null);
            }
        }

        [HttpGet("{hotelId}/Fotos")]
        public async Task<ActionResult<ResponseGetAllFotoHotel>> GetAllFotos(int hotelId)
        {
            try
            {
                var fotos = await _fotoService.GetAll(hotelId);
                return Ok(fotos);
            }
            catch
            {
                return StatusCode(500, null);
            }
        }

    }
}