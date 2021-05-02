using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.API.Controllers
{
    [Route("api/[controller]")]
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

        /*
        [HttpGet]
        public async Task<ActionResult<List<ResponseGetAllHotelDto>>> GetAllHoteles()
        {
            var hoteles = await _hotelService.GetAll();
            return Ok(hoteles);
        }
        */

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
        [HttpGet()]
        public async Task<ActionResult<ResponseGetAllHotelsByPage>> GetHotelBy(
            [FromQuery(Name = "page")] int page, 
            [FromQuery(Name ="estrellas")] int estrellas, 
            [FromQuery(Name ="ciudad")] string ciudad)
        {
            if (page == 0)
                page = 1;
            else if (page < 0)
                return BadRequest();

            if (estrellas < 0 || estrellas > 5)
                return BadRequest();

            var hoteles = await _hotelService.GetAllBy(page, estrellas, ciudad);

            int pageSize = int.Parse(_configuration.GetSection("PageSize").Value);
            int hotelesCount = await _hotelService.GetHotelsCount();
            int pageCount = (hotelesCount / pageSize) + 1;

            var response = new ResponseGetAllHotelsByPage {
                Data = hoteles,
                ItemsCount = hoteles.Count,
                PageCount = pageCount,
                CurrentPage = page,
                PreviousPage = CrearUriPaginacion(page - 1, estrellas, ciudad, pageCount),
                NextPage = CrearUriPaginacion(page + 1, estrellas, ciudad, pageCount)
            };

            return Ok(response);
        }

        private string CrearUriPaginacion(int page, int estrellas, string ciudad, int pageCount)
        {
            if (page <= 0)
                return null;

            if (page > pageCount)
                return null;

            StringBuilder builder = new StringBuilder();
            builder.Append($"/api/Hotel/?page={page}");

            if (estrellas > 0)
                builder.Append($"&estrellas={estrellas}");

            if (ciudad != null)
                builder.Append($"&ciudad={ciudad}");

            return builder.ToString();
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
