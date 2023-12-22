using FluentValidation;
using WebLabApp.web.Models;

namespace WebLabApp.web.Validations
{
    public class SampleModelValidator : AbstractValidator<ValidationModel>
    {
        public SampleModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Age)
                .InclusiveBetween(18, 99).When(x => x.Age.HasValue).WithMessage("Age must be between 18 and 99.");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{3}-?[0-9]{6,12}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Salary)
                .GreaterThan(1000).When(x => x.Salary.HasValue).WithMessage("Salary must be greater than 1000.");

            RuleFor(x => x.Department).NotEmpty().WithMessage("Department is required.");

            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required.");
        }
    }
}
