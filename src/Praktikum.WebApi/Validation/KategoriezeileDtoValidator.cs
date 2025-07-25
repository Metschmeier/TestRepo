using FluentValidation;
using Praktikum.Types.DTOs;

namespace Praktikum.WebApi.Validation;

public class KategoriezeileDtoValidator : AbstractValidator<KategorieDto>
{
    public KategoriezeileDtoValidator()
    {
        RuleFor(x => x.KategorieNummer).NotEmpty().MinimumLength(4);
        RuleFor(x => x.Kategorie).NotEmpty();
    }
}
