using FluentValidation;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Validation;

public class BuchhaltungszeileDtoValidator : AbstractValidator<BuchhaltungszeileDto>
{
    public BuchhaltungszeileDtoValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Datum).NotEmpty();
        RuleFor(x => x.Typ).NotEmpty().Must(t => t == "Einkauf" || t == "Verkauf" || t == "Sonstiges").WithMessage("Typ muss Einkauf, Verkauf oder Sonstiges sein");
        RuleFor(x => x.Beschreibung).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Betrag).NotEqual(0).WithMessage("Betrag darf nicht 0 sein.");
    }
}