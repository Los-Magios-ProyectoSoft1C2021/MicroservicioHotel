using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Hotel.Domain.DTOs
{
    public class UsuarioDto
    {
        public Guid UsuarioId { get; set; }

        public Guid Rol { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public int Dni { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Nacionalidad { get; set; }

        public string Imagen { get; set; }


        // Relación con la tabla Rol
        public List<Rol> Roles { get; set; }

        // Relación con la tabla Reserva
        public List<Reserva> Reservas { get; set; }
    }
}
