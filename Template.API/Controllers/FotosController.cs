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
        private readonly IFotosService _fotosService;
        private readonly IHotelService _hotelService;

        public FotosHotelController(IFotosService fotoService, IHotelService hotelService)
        {
            _fotosService = fotoService;
            _hotelService = hotelService;
        }

        [HttpGet("{hotelId}/Fotos")]
        public async Task<ActionResult<ResponseGetAllFotoHotel>> GetAllFotos(int hotelId)
        {
            var fotos = await _fotosService.GetAll(hotelId);
            return Ok(fotos);
        }

        [HttpGet("{hotelId}/Fotos/{fotoHotelId}")]
        public async Task<ActionResult<ResponseGetFotoHotelById>> GetFotoById(int fotoHotelId, int hotelId)
        {
            var foto = await _fotosService.GetById(fotoHotelId, hotelId);
            if (foto == null)
                return NotFound();

            return Ok(foto);
        }

        [HttpPost("{hotelId}/Fotos")]
        public async Task<ActionResult<ResponseCreateFotoHotel>> PostFoto(int hotelId, RequestCreateFotoHotel request)
        {
            var exists = await _hotelService.CheckHotelExistsById(hotelId);
            if (!exists)
                return BadRequest();

            var createdFotoHotel = await _fotosService.Add(hotelId, request);
            if (createdFotoHotel == null)
                throw new Exception();

            return Created(uri: $"{createdFotoHotel.HotelId}/Fotos/{createdFotoHotel.FotoHotelId}", createdFotoHotel);
        }

    }
}