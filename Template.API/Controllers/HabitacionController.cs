using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Request.Habitacion;
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
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionService _habitacionService;
        private readonly IHotelService _hotelService;

        public HabitacionController(IHabitacionService habitacionService, IHotelService hotelService)
        {
            _habitacionService = habitacionService;
            _hotelService = hotelService;
        }

        [HttpGet("{hotelId}/Habitacion/{habitacionId}")]
        public async Task<ActionResult<ResponseGetHabitacionByIdDto>> GetById(int hotelId, int habitacionId)
        {
            try
            {
                var habitacion = await _habitacionService.GetHabitacionById(habitacionId, hotelId);
                if (habitacion == null)
                    return NotFound();

                return Ok(habitacion);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
        
        [HttpPost("{hotelId}/Habitacion")]
        public async Task<ActionResult> PostHabitacion(int hotelId, RequestCreateHabitacionDto habitacion)
        {
            try
            {
                var exists = await _hotelService.CheckHotelExistsById(hotelId);
                if (!exists)
                    return BadRequest();

                var createdHotel = await _habitacionService.Create(habitacion);
                return Created(uri: $"api/Hotel/{createdHotel.HotelId}/Habitacion/{createdHotel.HabitacionId}", createdHotel);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPut("{hotelId}/Habitacion/{habitacionId}")]
        public async Task<ActionResult> PutHabitacion(int hotelId, int habitacionId, RequestUpdateHabitacionDto habitacion)
        {
            try
            {
                var habitacionExists = await _habitacionService.CheckHabitacionExistById(habitacionId,  hotelId);
                if (!habitacionExists)
                    return NotFound();

                await _habitacionService.Update(habitacion);

                var updatedHabitacion = _habitacionService.GetHabitacionById(habitacionId, hotelId);
                if (updatedHabitacion == null)
                    return StatusCode(500, null);

                return StatusCode(204, updatedHabitacion); // 204: Recurso modificado
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
