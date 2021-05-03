using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/Hotel")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionService _habitacionService;
        private readonly IHotelService _hotelService;

        public HabitacionController(IHabitacionService habitacionService, IHotelService hotelService)
        {
            _habitacionService = habitacionService;
            _hotelService = hotelService;
        }

        [HttpGet("{hotelId}/Habitacion")]
        public async Task<ActionResult<List<ResponseHabitacionDto>>> GetAll(int hotelId)
        {
            var habitaciones = await _habitacionService.GetAllHabitaciones(hotelId);
            if (habitaciones.Count <= 0)
                return StatusCode(204, null);

            return Ok(habitaciones);
        }

        [HttpGet("{hotelId}/Habitacion/{habitacionId}")]
        public async Task<ActionResult<ResponseHabitacionDto>> GetById(int hotelId, int habitacionId)
        {
            var habitacion = await _habitacionService.GetHabitacionById(habitacionId, hotelId);
            if (habitacion == null)
                return NotFound();

            return Ok(habitacion);
        }
        
        [HttpPost("{hotelId}/Habitacion")]
        public async Task<ActionResult> PostHabitacion(int hotelId, RequestHabitacionDto habitacion)
        {
            var exists = await _hotelService.CheckHotelExistsById(hotelId);
            if (!exists)
                return BadRequest();

            var createHabitacion = await _habitacionService.Create(habitacion);
            return Created(uri: $"api/Hotel/{createHabitacion.HotelId}/Habitacion/{createHabitacion.HabitacionId}", createHabitacion);
        }

        [HttpPut("{hotelId}/Habitacion/{habitacionId}")]
        public async Task<ActionResult> PutHabitacion(int hotelId, int habitacionId, RequestHabitacionDto habitacion)
        {
            var habitacionExists = await _habitacionService.CheckHabitacionExistById(habitacionId, hotelId);
            if (!habitacionExists)
                return StatusCode(204, null); // 204: Recurso no encontrado

            var updatedHabitacion = await _habitacionService.Update(habitacionId, hotelId, habitacion);
            if (updatedHabitacion == null)
                return StatusCode(500, null);

            return Ok(updatedHabitacion);
        }
    }
}
