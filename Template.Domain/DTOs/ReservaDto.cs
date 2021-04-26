﻿using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Hotel.Domain.DTOs
{
    public class ReservaDto
    {
        public Guid ReservaId { get; set; }

        public Guid UsuarioId { get; set; }

        public Guid HabitacionId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }


        // Relación con la tabla Usuario
        public Usuario Usuario { get; set; }

        // Relación con la tabla Habitacion
        public Habitacion Habitacion { get; set; }
    }
}
