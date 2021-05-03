﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.Domain.DTOs.Response
{
    public class ResponseHotelDto
    {
        public int HotelId { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string DireccionNum { get; set; }
        public string DireccionObservaciones { get; set; }
        public string CodigoPostal { get; set; }
        public int Estrellas { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }

        public List<ResponseHabitacionCategoriaDto> Fotos { get; set; }
    }

    public class ResponseHabitacionCategoriaDto
    {
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
    }
}