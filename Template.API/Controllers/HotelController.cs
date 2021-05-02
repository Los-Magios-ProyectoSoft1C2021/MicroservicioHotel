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
            var hoteles = await _hotelService.GetAll();
            return Ok(hoteles);
        }

        // GET: api/Hotel/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseGetHotelByIdDto>> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        // GET: /api/[controller]/query
        [HttpGet("filter")]
        public async Task<ActionResult<List<ResponseGetAllHotelBy>>> GetHotelBy(
            [FromQuery(Name = "page")] int page, 
            [FromQuery(Name ="estrellas")] int estrellas, 
            [FromQuery(Name ="ciudad")] string ciudad)
        {
            if (page == 0)
                page = 1;

            var hoteles = await _hotelService.GetAllBy(page, estrellas, ciudad);
            return Ok(hoteles);
        }

        // POST: api/Hotel/
        [HttpPost]
        public async Task<ActionResult> PostHotel(RequestCreateHotelDto hotel)
        {
            var createdHotel = await _hotelService.Create(hotel);
            if (createdHotel == null)
                throw new Exception();

            return Created(uri: $"api/Hotel/{createdHotel.HotelId}", createdHotel);
        }

        // PUT: api/Hotel/
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseUpdateHotel>> PutHotel(int id, RequestUpdateHotelDto hotel)
        {
            var exists = await _hotelService.CheckHotelExistsById(id);
            if (!exists)
                return StatusCode(204, null); // 204: Recurso no encontrado

            var updatedHotel = await _hotelService.Update(id, hotel);
            if (updatedHotel == null)
                throw new Exception();

            return Ok(updatedHotel);
        }
    }
}
