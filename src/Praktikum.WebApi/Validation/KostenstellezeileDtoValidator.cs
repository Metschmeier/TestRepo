using FluentValidation;
using Praktikum.Types.DTOs;

namespace Praktikum.WebApi.Validation;

public class KostenstellezeileDtoValidator : AbstractValidator<KostenstelleDto>
{
    public KostenstellezeileDtoValidator()
    {
        RuleFor(x => x.Kostenstelle).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Beschreibung).NotEmpty();
    }
}
