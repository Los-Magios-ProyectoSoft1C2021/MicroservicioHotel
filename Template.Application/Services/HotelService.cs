using AutoMapper;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IGenericsRepository _repository;
        private readonly IHotelQuery _query;
        private readonly IMapper _mapper;

        public HotelService(IGenericsRepository repository, IHotelQuery query, IMapper mapper)
        {
            _repository = repository;
            _query = query;
            _mapper = mapper;
        }

        public async Task<ResponseCreateHotel> Create(RequestCreateHotelDto request)
        {
            var h = _mapper.Map<Hotel>(request);
            await _repository.Add(h);

            return _mapper.Map<ResponseCreateHotel>(h);
        }

        public async Task<ResponseUpdateHotel> Update(RequestUpdateHotelDto hotel)
        {
            var h = _mapper.Map<Hotel>(hotel);
            await _repository.Update(h);

            return _mapper.Map<ResponseUpdateHotel>(h);
        }

        public async Task<ResponseGetHotelByIdDto> GetById(int id)
        {
            return await _query.GetById(id);
        }

        public async Task<List<ResponseGetAllHotelDto>> GetAll()
        {
            return await _query.GetAll();
        }

        public async Task<List<ResponseGetAllHotelBy>> GetAllBy(int page, int estrellas, string ciudad)
        {
            return await _query.GetAllBy(page, estrellas, ciudad);
        }

        public async Task<bool> CheckHotelExistsById(int id)
        {
            return await _query.CheckHotelExistsById(id);
        }
    }
}
