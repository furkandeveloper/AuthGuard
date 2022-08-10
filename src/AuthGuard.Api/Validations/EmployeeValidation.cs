using AuthGuard.Application.Dtos;
using FluentValidation;

namespace AuthGuard.Api.Validations
{
    public class EmployeeValidator : AbstractValidator<EmployeeRequestDto>
    {
        public EmployeeValidator()
        {
            RuleFor(r => r.FirstName).NotNull().NotEmpty();
            RuleFor(r => r.LastName).NotNull().NotEmpty();
            RuleFor(r => r.Age).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
