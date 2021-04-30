using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<ResponseGetAllHotelDto> GetAllHoteles()
        {
            return _hotelService.GetAll();
        }

        // GET: api/Hotel/{id}
        [HttpGet("{id}")]
        public ResponseGetHotelByIdDto GetHotelById(int id)
        {
            return _hotelService.GetById(id);
        }

        // GET: /api/[controller]/query
        [HttpGet("filter")]
        public List<ResponseGetAllHotelBy> GetHotelBy(
            [FromQuery(Name = "page")] int page, 
            [FromQuery(Name ="estrellas")] int estrellas, 
            [FromQuery(Name ="ciudad")] string ciudad)
        {
            return _hotelService.GetAllBy(page, estrellas, ciudad);
        }

        // POST: api/Hotel/
        [HttpPost]
        public IActionResult PostHotel(RequestCreateHotelDto hotel)
        {
            _hotelService.Create(hotel);
            return Created(uri: "api/Hotel/2", null);
        }

        // PUT: api/Hotel/?ciudad={ciudad}&estrelllas={estrellas}
        [HttpPut]
        public void PutHotel([FromQuery(Name = "id")] int id, RequestUpdateHotelDto hotel)
        {
            _hotelService.Update(hotel);
        }
    }
}
