using FluentValidation;
using Praktikum.Types.DTOs;

namespace Praktikum.WebApi.Validation;

public class BuchhaltungszeileDtoValidator : AbstractValidator<BuchungDto>
{
    public BuchhaltungszeileDtoValidator()
    {
        //RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Datum).NotEmpty();
        RuleFor(x => x.Typ).NotEmpty().Must(t => t == "Einkauf" || t == "Verkauf" || t == "Sonstiges").WithMessage("Typ muss Einkauf, Verkauf oder Sonstiges sein");
        RuleFor(x => x.Beschreibung).NotEmpty().MinimumLength(3);
        RuleFor(x => x.BetragNetto).NotEqual(0).WithMessage("Betrag darf nicht 0 sein.");
    }
}