using FluentValidation;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Validation;

public class PartnerzeileDtoValidator : AbstractValidator<PartnerzeileDto>
{
    public PartnerzeileDtoValidator()
    {
        RuleFor(x => x.PartnerId).GreaterThan(0);
        RuleFor(x => x.Kontonummer).NotEmpty();
        RuleFor(x => x.PartnerName).NotEmpty().MinimumLength(5);
        RuleFor(x => x.PartnerTyp).NotEmpty().MinimumLength(4);
    }
}
