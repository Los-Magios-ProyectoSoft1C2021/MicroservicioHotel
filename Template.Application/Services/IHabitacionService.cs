using System;
using System.Collections.Generic;
using System.Text;
using MicroservicioHotel.Domain.DTOs;
using MicroservicioHotel.Domain.DTOs.Request.Habitacion;

namespace MicroservicioHotel.Application.Services
{
    public interface IHabitacionService
    {
        void Create(RequestCreateHabitacionDto request);
        void Update(RequestUpdateHabitacionDto request);

        ResponseGetHabitacionByIdDto GetIdHabitacion(int id);

        ResponseGetHabitacionByIdDto GetAllHabitacion();

        //void GetEstadoHabitacion(int id);
    }
}
