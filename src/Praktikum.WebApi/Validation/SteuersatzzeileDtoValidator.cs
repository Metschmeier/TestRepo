using FluentValidation;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Validation;

    public class SteuersatzzeileDtoValidator : AbstractValidator<SteuersatzzeileDto>
{
    public SteuersatzzeileDtoValidator()
    {
        RuleFor(x => x.SteuersatzId).GreaterThan(0);
        RuleFor(x => x.SteuersatzInProzent).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Prozentsatz).NotEmpty();
    }
}
