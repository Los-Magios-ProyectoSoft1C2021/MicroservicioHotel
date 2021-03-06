using AutoMapper;
using MicroservicioHotel.Application.HttpService;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs.Request;
using MicroservicioHotel.Domain.DTOs.Response;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IGenericsRepository _repository;
        private readonly IHotelQuery _query;
        private readonly MicroservicioReservaService _reservaService;
        private readonly IMapper _mapper;

        public HotelService(IGenericsRepository repository, IHotelQuery query, MicroservicioReservaService reservaService, IMapper mapper)
        {
            _repository = repository;
            _query = query;
            _reservaService = reservaService;
            _mapper = mapper;
        }

        public async Task<ResponseHotelDto> Create(RequestHotelDto request)
        {
            var h = _mapper.Map<Hotel>(request);
            await _repository.Add(h);

            return _mapper.Map<ResponseHotelDto>(h);
        }

        public async Task<ResponseHotelDto> Update(int id, RequestHotelDto hotel)
        {
            var h = _mapper.Map<Hotel>(hotel);
            h.HotelId = id;

            await _repository.Update(h);

            return await _query.GetById(id);
        }

        public async Task<ResponseHotelDto> Patch(int id, JsonPatchDocument<RequestHotelDto> entityPatchDto)
        {
            var oldHotel = await _query.GetById(id);
            var entityPatch = _mapper.Map<JsonPatchDocument<Hotel>>(entityPatchDto);

            var modifiedHotel = _mapper.Map<Hotel>(oldHotel);
            entityPatch.ApplyTo(modifiedHotel);
            modifiedHotel.HotelId = id;

            await _repository.Update(modifiedHotel);
            return await _query.GetById(id);
        }

        public async Task<ResponseHotelDto> GetById(int id)
        {
            return await _query.GetById(id);
        }

        public async Task<List<ResponseHotelSimpleDto>> GetAll()
        {
            return await _query.GetAll();
        }

        public async Task<List<ResponseHotelSimpleDto>> GetAllBy(int page, int estrellas, string ciudad, int categoria, DateTime fechaInicio, DateTime fechaFin)
        {
            var reservas = await _reservaService.GetHabitacionesReservadasEntre(fechaInicio, fechaFin);
            return await _query.GetAllBy(page, estrellas, ciudad, categoria, reservas);
        }

        public async Task<bool> CheckIfExistsById(int id)
        {
            return await _query.CheckHotelExistsById(id);
        }

        public async Task<int> GetHotelsCount(int estrellas, string ciudad, int categoria, DateTime fechaInicio, DateTime fechaFin)
        {
            var reservas = await _reservaService.GetHabitacionesReservadasEntre(fechaInicio, fechaFin);
            return await _query.GetHotelsCount(estrellas, ciudad, categoria, reservas);
        }

    }
}
