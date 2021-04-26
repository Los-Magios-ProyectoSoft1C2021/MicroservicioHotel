using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Entities
{
    public class Rol
    {
        public Guid RolId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        // Relación con la tabla Usuario
        public Usuario Usuario { get; set; }
    }
}
