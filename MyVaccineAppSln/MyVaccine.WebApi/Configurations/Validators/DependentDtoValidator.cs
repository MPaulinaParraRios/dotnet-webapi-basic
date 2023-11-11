using FluentValidation;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Configurations.Validators;

public class DependentDtoValidator : AbstractValidator<DependentRequestDto>
{
    public DependentDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().MaximumLength(255);
        RuleFor(dto => dto.DateOfBirth).NotEmpty().GreaterThan(DateTime.Now);
        RuleFor(dto => dto.UserId).NotEmpty().GreaterThan(0);
    }
}
