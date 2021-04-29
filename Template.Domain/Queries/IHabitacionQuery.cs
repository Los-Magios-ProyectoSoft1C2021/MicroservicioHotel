using MicroservicioHotel.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.Queries
{
    public interface IHabitacionQuery
    {
        //Consultas.....
        List<ResponseGetHabitacionByIdDto> GetAllHabitacion();
        ResponseGetHabitacionByIdDto GetIdHabitacion(int id);
    }
}
