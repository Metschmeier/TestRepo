using FluentValidation;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Validation;

public class KategoriezeileDtoValidator : AbstractValidator<KategoriezeileDto>
{
    public KategoriezeileDtoValidator()
    {
        //RuleFor(x => x.KategorieId).NotEmpty();
        RuleFor(x => x.KategorieNummer).NotEmpty().MinimumLength(4);
        RuleFor(x => x.KategorieName).NotEmpty();
    }
}
