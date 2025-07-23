using FluentValidation;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Validation;

public class KostenstellezeileDtoValidator : AbstractValidator<KostenstellezeileDto>
{
    public KostenstellezeileDtoValidator()
    {
        RuleFor(x => x.KostenstelleOrt).NotEmpty().MinimumLength(3);
        RuleFor(x => x.KostenstelleBeschreibung).NotEmpty();
    }
}
