using AutoMapper;
using MicroservicioHotel.Domain.Commands;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.Entities;
using MicroservicioHotel.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Application.Services
{
    public class HabitacionService: IHabitacionService
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

        public ResponseGetHabitacionByIdDto GetAllHabitacion()
        {
            throw new NotImplementedException();
        }

        public ResponseGetHabitacionByIdDto GetIdHabitacion(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(RequestCreateHabitacionDto request)
        {
            var h =  _mapper.Map<Habitacion>(request);
            _repository.Add(h);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

    }
}
