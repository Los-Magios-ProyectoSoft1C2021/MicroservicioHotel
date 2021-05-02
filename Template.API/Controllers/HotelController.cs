using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseGetAllHotelDto>>> GetAllHoteles()
        {
            try
            {
                var hoteles = await _hotelService.GetAll();
                return Ok(hoteles);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // GET: api/Hotel/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseGetHotelByIdDto>> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelService.GetById(id);
                if (hotel == null)
                    return NotFound();

                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // GET: /api/[controller]/query
        [HttpGet("filter")]
        public async Task<ActionResult<List<ResponseGetAllHotelBy>>> GetHotelBy(
            [FromQuery(Name = "page")] int page, 
            [FromQuery(Name ="estrellas")] int estrellas, 
            [FromQuery(Name ="ciudad")] string ciudad)
        {
            try
            {
                var hoteles = await _hotelService.GetAllBy(page, estrellas, ciudad);
                return Ok(hoteles);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // POST: api/Hotel/
        [HttpPost]
        public async Task<ActionResult> PostHotel(RequestCreateHotelDto hotel)
        {
            try
            {
                var createdHotel = await _hotelService.Create(hotel);
                if (createdHotel == null)
                    throw new Exception();

                return Created(uri: $"api/Hotel/{createdHotel.HotelId}", createdHotel);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // PUT: api/Hotel/
        [HttpPut]
        public async Task<ActionResult<ResponseUpdateHotel>> PutHotel([FromQuery(Name = "id")] int id, RequestUpdateHotelDto hotel)
        {
            try
            {
                var exists = await _hotelService.CheckHotelExistsById(id);
                if (!exists)
                    return NotFound();

                var updatedHotel = await _hotelService.Update(hotel);
                if (updatedHotel == null)
                    throw new Exception();

                return StatusCode(204, updatedHotel); // 204: Recurso modificado
            } 
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
