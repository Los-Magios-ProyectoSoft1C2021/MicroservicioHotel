using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponseCategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
