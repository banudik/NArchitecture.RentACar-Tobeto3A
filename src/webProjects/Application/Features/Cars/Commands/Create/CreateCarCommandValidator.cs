using Application.Features.Cars.Constants;
using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(b => b.ModelId).NotEmpty().WithMessage(CarValidatorMessages.ModelNotBlank);
        RuleFor(b => b.Plate).MinimumLength(5);
        RuleFor(b => b.Plate).NotEmpty().WithMessage(CarValidatorMessages.PlateNotBlank);
    }
}
