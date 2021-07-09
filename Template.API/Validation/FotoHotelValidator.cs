using FluentValidation;
using MicroservicioHotel.Domain.DTOs.Request;

namespace MicroservicioHotel.API.Validation
{
    public class FotoHotelValidator : AbstractValidator<RequestFotoHotelDto>
    {
        public FotoHotelValidator()
        {
            RuleFor(fh => fh.ImagenUrl)
                .NotEmpty().WithMessage("La URL de la imagen no puede estar vacía")
                .MaximumLength(128).WithMessage("La URL de la imagen no puede tener más de 128 caracteres");

            RuleFor(fh => fh.Descripcion)
                .NotEmpty().WithMessage("La descripción de la foto no puede estar vacía")
                .MaximumLength(128).WithMessage("La descripción de la imagen no puede tener más de 128 caracteres");
        }
    }
}
