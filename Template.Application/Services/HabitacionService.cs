using AutoMapper;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs.Request.Habitacion;
using MicroservicioHotel.Domain.DTOs.Response.Habitacion;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<ResponseGetHabitacionByIdDto> GetAllHabitaciones(int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseGetHabitacionByIdDto> GetHabitacionById(int habitacionId, int hotelId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseCreateHabitacion> Create(RequestCreateHabitacionDto request)
        {
            var h =  _mapper.Map<Habitacion>(request);
            await _repository.Add(h);

            return _mapper.Map<ResponseCreateHabitacion>(h);
        }

        public async Task<ResponseUpdateHabitacion> Update(RequestUpdateHabitacionDto request)
        {
            var h = _mapper.Map<Habitacion>(request);
            await _repository.Update(h);

            return _mapper.Map<ResponseUpdateHabitacion>(h);
        }

        public async Task<bool> CheckHabitacionExistById(int habitacionId, int hotelId)
        {
            return await _query.CheckHabitacionExistById(habitacionId, hotelId);
        }
    }
}
