﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs
{
    public class ResponseGetHabitacionByIdDto
    {
        public int HabitacionId { get; set; }
        public int HotelId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
    }
}