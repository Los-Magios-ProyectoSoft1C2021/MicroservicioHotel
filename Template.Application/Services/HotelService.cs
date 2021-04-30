using AutoMapper;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Response.Hotel;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Create(RequestCreateHotelDto request)
        {
            var h = _mapper.Map<Hotel>(request);
            _repository.Add(h);
        }

        public void Update(RequestUpdateHotelDto hotel)
        {
            var h = _mapper.Map<Hotel>(hotel);
            _repository.Update(h);
        }

        public ResponseGetHotelByIdDto GetById(int id)
        {
            return _query.GetById(id);
        }

        public List<ResponseGetAllHotelDto> GetAll()
        {
            return _query.GetAll();
        }

        public List<ResponseGetAllHotelBy> GetAllBy(int page, int estrellas, string ciudad)
        {
            return _query.GetAllBy(page, estrellas, ciudad);
        }
    }
}
