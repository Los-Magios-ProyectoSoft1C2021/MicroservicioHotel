using AutoMapper;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs.Request.FotoHotel;
using MicroservicioHotel.Domain.DTOs.Response.FotoHotel;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicioHotel.Application.Services
{
    public class FotosService : IFotosService
    {
        private readonly IGenericsRepository _repository;
        private readonly IFotoHotelQuery _query;
        private readonly IMapper _mapper;

        public FotosService(IFotoHotelQuery query, IGenericsRepository repository, IMapper mapper)
        {
            _query = query;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseCreateFotoHotel> Add(int hotelId, RequestCreateFotoHotel request)
        {
            var foto = _mapper.Map<FotoHotel>(request);
            foto.HotelId = hotelId;

            await _repository.Add(foto);

            return _mapper.Map<ResponseCreateFotoHotel>(foto);
        }

        public async Task<bool> CheckFotoExistsById(int fotoHotelId, int hotelId)
        {
            return await _query.CheckFotoHotelExistsById(fotoHotelId, hotelId);
        }

        public async Task<List<ResponseGetAllFotoHotel>> GetAll(int hotelId)
        {
            return await _query.GetAll(hotelId);
        }

        public async Task<ResponseGetFotoHotelById> GetById(int fotoHotelId, int hotelId)
        {
            return await _query.GetById(fotoHotelId, hotelId);
        }

        public async Task Remove(int fotoHotelId, int hotelId)
        {
            var f = _query.GetById(fotoHotelId, hotelId);

            var fotoHotel = _mapper.Map<FotoHotel>(f);
            await _repository.Remove(fotoHotel);
        }
    }
}
