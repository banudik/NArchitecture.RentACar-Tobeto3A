using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Constants;
using Application.Features.Models.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandValidator: AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage(ModelValidatorMessages.NameNotBlank);
        RuleFor(b => b.Name).MinimumLength(5);
        RuleFor(b => b.BrandId).NotEmpty().WithMessage(ModelValidatorMessages.BrandNotBlank);
    }
}

