using AutoMapper;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IGenericsRepository _repository;
        private readonly IHabitacionQuery _query;
        private readonly IMapper _mapper;

        public HabitacionService(IGenericsRepository repository, IHabitacionQuery query, IMapper mapper)
        {
            _repository = repository;
            _query = query;
            _mapper  = mapper; 
        }

        public async Task<List<ResponseHabitacionDto>> GetAllHabitaciones(int hotelId, int categoriaId)
        {
            return await _query.GetAllHabitaciones(hotelId, categoriaId);
        }

        public async Task<ResponseHabitacionDto> GetHabitacionById(int habitacionId, int hotelId)
        {
            return await _query.GetHabitacionById(habitacionId, hotelId);
        }

        public async Task<ResponseHabitacionDto> Create(int hotelId, RequestHabitacionDto request)
        {
            var h =  _mapper.Map<Habitacion>(request);
            h.HotelId = hotelId;

            await _repository.Add(h);

            var createdHabitacion = await _query.GetHabitacionById(h.HabitacionId, h.HotelId);

            return _mapper.Map<ResponseHabitacionDto>(createdHabitacion);
        }

        public async Task<ResponseHabitacionDto> Update(int habitacionId, int hotelId, RequestHabitacionDto request)
        {
            var h = _mapper.Map<Habitacion>(request);
            h.HabitacionId = habitacionId;
            h.HotelId = hotelId;

            await _repository.Update(h);

            return await _query.GetHabitacionById(habitacionId, hotelId);
        }

        public async Task<ResponseHabitacionDto> Patch(int habitacionId, int hotelId, JsonPatchDocument<RequestHabitacionDto> entityPatchDto)
        {
            var oldHabitacion = await _query.GetHabitacionDataById(habitacionId, hotelId);
            var entityPatch = _mapper.Map<JsonPatchDocument<Habitacion>>(entityPatchDto);

            var modifiedHabitacion = _mapper.Map<Habitacion>(oldHabitacion);
            entityPatch.ApplyTo(modifiedHabitacion);
            modifiedHabitacion.HotelId = hotelId;
            modifiedHabitacion.HabitacionId = habitacionId;

            await _repository.Update(modifiedHabitacion);
            return await _query.GetHabitacionById(habitacionId, hotelId);
        }
        
        public async Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId)
        {
            return await _query.CheckHabitacionExistById(habitacionId, hotelId);
        }
    }
}
