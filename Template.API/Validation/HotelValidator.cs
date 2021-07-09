using FluentValidation;
using MicroservicioHotel.Domain.DTOs.Request;

namespace MicroservicioHotel.API.Validation
{
    public class HotelValidator : AbstractValidator<RequestHotelDto>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Nombre)
                .NotEmpty().WithMessage("El nombre del hotel no puede estar vacío")
                .MaximumLength(128).WithMessage("El nombre del hotel no puede tener más de 128 caracteres");

            RuleFor(h => h.Longitud)
                .NotNull().WithMessage("La latitud no puede ser nula");

            RuleFor(h => h.Longitud)
                .NotNull().WithMessage("La longitud no puede ser nula");

            RuleFor(h => h.Provincia)
                .NotEmpty().WithMessage("La provincia no puede estar vacía")
                .MaximumLength(64).WithMessage("La provincia no puede tener más de 64 caracteres");

            RuleFor(h => h.Ciudad)
                .NotEmpty().WithMessage("La ciudad no puede estar vacía")
                .MaximumLength(128).WithMessage("La ciudad no puede tener más de 128 caracteres");

            RuleFor(h => h.Direccion)
                .NotEmpty().WithMessage("La dirección no puede estar vacía")
                .MaximumLength(128).WithMessage("La dirección no puede tener más de 128 caracteres");

            RuleFor(h => h.DireccionNum)
                .NotEmpty().WithMessage("El número de la dirección no puede estar vacía")
                .MaximumLength(16).WithMessage("El número de la dirección no puede tener más de 16 caracteres");

            RuleFor(h => h.DireccionObservaciones)
                .MaximumLength(128).WithMessage("Las observaciones de la dirección no pueden tener más de 128 caracteres");

            RuleFor(h => h.CodigoPostal)
                .NotEmpty().WithMessage("El código postal no puede estar vacío")
                .MaximumLength(24).WithMessage("El código postal no puede tener más de 24 caracteres");

            RuleFor(h => h.Estrellas)
                .NotNull().WithMessage("Las estrellas no pueden ser nulas")
                .InclusiveBetween(1, 5).WithMessage("El hotel puede tener entre 1 y 5 estrellas");

            RuleFor(h => h.Telefono)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío")
                .MaximumLength(16).WithMessage("El teléfono no puede tener más de 16 caracteres");

            RuleFor(h => h.Correo)
                .NotEmpty().WithMessage("El correo no puede estar vacío")
                .MaximumLength(128).WithMessage("El correo no puede tener más de 128 caracteres");
        }
    }
}
