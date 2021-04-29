using System;
using System.Collections.Generic;
using System.Text;
using MicroservicioHotel.Domain.DTOs;

namespace MicroservicioHotel.Application.Services
{
    public interface IHabitacionService
    {
        void Create(RequestCreateHabitacionDto request);
        void Update();

        ResponseGetHabitacionByIdDto GetIdHabitacion(int id);

        ResponseGetHabitacionByIdDto GetAllHabitacion();

        //void GetEstadoHabitacion(int id);
    }
}
