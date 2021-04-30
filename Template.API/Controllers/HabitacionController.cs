using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroservicioHotel.API.Controllers
{
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionService _habitacionService;
        private readonly ILogger<HabitacionController> _logger;

        public HabitacionController(IHabitacionService habitacionService, ILogger<HabitacionController> logger)
        {
            _habitacionService = habitacionService;
            _logger = logger;
        }


        [Route("/api/Hotel/{hotelId}/Habitacion/{habitacionId}")]
        [HttpGet]
        public ResponseGetHabitacionByIdDto GetById(int hotelId, int habitacionId)
        {
            _logger.LogInformation($"HabitacionController: GetById: HabitacionId = {habitacionId}");
            return null;
            //return _habitacionService.GetIdHabitacion(habitacionId);
        }
        
        [Route("/api/Hotel/{hotelId}/Habitacion")]
        [HttpPost]
        public IActionResult PostHabitacion(RequestCreateHabitacionDto habitacion)
        {
            _habitacionService.Create(habitacion);
            return Created(uri: "api/Hotel/Habitacion/", null);
        }
    }
}
