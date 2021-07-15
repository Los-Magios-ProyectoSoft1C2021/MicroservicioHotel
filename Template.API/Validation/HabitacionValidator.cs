using FluentValidation;
using MicroservicioHotel.Application.Services;
using MicroservicioHotel.Domain.DTOs.Request;

namespace MicroservicioHotel.API.Validation
{
    public class HabitacionValidator : AbstractValidator<RequestHabitacionDto>
    {
        public HabitacionValidator(ICategoriaService categoriaService)
        {
            RuleFor(h => h.CategoriaId)
                .MustAsync(async (x, cancellation) => { return (await categoriaService.CheckIfExists(x)); })
                .WithMessage("No se ha ingresado un ID de categoria válido");

            RuleFor(h => h.Nombre)
                .NotEmpty().WithMessage("El nombre no puede estar vacío")
                .MaximumLength(64).WithMessage("El nombre de la habitación no puede tener más de 64 caracteres");
        }
    }
}
