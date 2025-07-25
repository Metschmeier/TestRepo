using FluentValidation;
using Praktikum.Types.DTOs;

namespace Praktikum.WebApi.Validation;

    public class SteuersatzzeileDtoValidator : AbstractValidator<SteuersatzDto>
{
    public SteuersatzzeileDtoValidator()
    {
        //RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Bezeichnung).NotEmpty();
        //RuleFor(x => x.Prozentsatz).NotEmpty();
    }
}
