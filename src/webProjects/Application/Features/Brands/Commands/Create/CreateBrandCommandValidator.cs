using Application.Features.Brands.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator: AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage(BrandValidatorMessages.NameNotBlank);
        RuleFor(b => b.Name).MinimumLength(2);
    }
}
