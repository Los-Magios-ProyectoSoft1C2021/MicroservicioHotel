﻿using MicroservicioHotel.Application.Services;
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
    [Route("api/hotel")]
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

        /// <summary>
        /// Retorna todas las habitaciones de un hotel.
        /// </summary>
        /// <param name="hotelId">La id de del hotel</param>
        /// <returns>Retorna todas las habitaciones de un hotel.</returns>
        /// /// <response code="200">Retorna la información de las habitaciónes</response>
        /// <response code="204">Si no se encuentran habitaciones en dicho hotel</response>  
        [HttpGet("{hotelId:int}/habitacion")]
        public async Task<ActionResult<List<ResponseHabitacionDto>>> GetAll(int hotelId)
        {
            var habitaciones = await _habitacionService.GetAllHabitaciones(hotelId);
            if (habitaciones.Count <= 0)
                return StatusCode(204, null);

            return Ok(habitaciones);
        }

        /// <summary>
        /// Retorna las habitaciones por Id.
        /// </summary>
        /// <param name="hotelId">la id del hotel.</param>
        /// <param name="habitacionId">la id de la foto.</param>
        /// <returns>Retorna las habitaciones por Id.</returns>
        /// <response code="200">Retorna la información de la habitación</response>
        /// <response code="404">Si no se encuentra la habitacion correspondiente a dicho hotel</response>  
        [HttpGet("{hotelId:int}/habitacion/{habitacionId:int}")]
        public async Task<ActionResult<ResponseHabitacionDto>> GetById(int hotelId, int habitacionId)
        {
            var habitacion = await _habitacionService.GetHabitacionById(habitacionId, hotelId);
            if (habitacion == null)
                return NotFound();

            return Ok(habitacion);
        }

        /// <summary>
        /// Carga una habitacion al servidor.
        /// </summary>
        /// <remarks>
        /// Ejemplo de body:
        ///   {
        ///     "HotelId": 1,
        ///     "CategoriaId": 1,
        ///     "Nombre": "A1"
        ///   }
        /// </remarks>
        /// <param name="hotelId">la id del hotel.</param>
        /// <param name="habitacion">Body que contiene la informacion de la habitacion.</param>
        /// <returns>Carga una habitacion al servidor.</returns>
        /// <response code="201">Retorna la creacion de la habitacion</response>
        /// <response code="400">Si no se encuentra la habitacion</response>  
        [HttpPost("{hotelId:int}/habitacion")]
        public async Task<ActionResult> PostHabitacion(int hotelId, RequestHabitacionDto habitacion)
        {
            var exists = await _hotelService.CheckHotelExistsById(hotelId);
            if (!exists)
                return BadRequest();

            var createHabitacion = await _habitacionService.Create(habitacion);
            return Created(uri: $"api/hotel/{createHabitacion.HotelId}/habitacion/{createHabitacion.HabitacionId}", createHabitacion);
        }

        /// <summary>
        /// Actualiza la habitacion.
        /// </summary>
        /// Ejemplo de body:
        ///   {
        ///     "CategoriaId": 2,
        ///     "Nombre": "B1"
        ///   }
        /// <param name="hotelId">la id del hotel.</param>
        /// <param name="habitacionId">la id de la habitacion.</param>
        /// <param name="habitacion">Body que contiene la informacion de la habitacion</param>
        /// <returns>Carga una habitacion al servidor.</returns>
        /// <response code="200">Retorna la información de la habitacion modificada</response>
        /// <response code="204">Si no se encuentra la habitacion a modificar</response> 
        [HttpPut("{hotelId:int}/habitacion/{habitacionId:int}")]
        public async Task<ActionResult> PutHabitacion(int hotelId, int habitacionId, RequestHabitacionDto habitacion)
        {
            var habitacionExists = await _habitacionService.CheckHabitacionExistById(habitacionId, hotelId);
            if (!habitacionExists)
                return StatusCode(204, null); // 204: Recurso no encontrado

            var updatedHabitacion = await _habitacionService.Update(habitacionId, hotelId, habitacion);
            if (updatedHabitacion == null)
                throw new Exception();

            return Ok(updatedHabitacion);
        }
    }
}
