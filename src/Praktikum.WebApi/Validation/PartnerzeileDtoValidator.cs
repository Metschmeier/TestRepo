using FluentValidation;
using Praktikum.Types.DTOs;

namespace Praktikum.WebApi.Validation;

public class PartnerzeileDtoValidator : AbstractValidator<PartnerDto>
{
    public PartnerzeileDtoValidator()
    {
        //RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Kontonummer).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(5);
        RuleFor(x => x.Typ).NotEmpty().MinimumLength(4);
    }
}
