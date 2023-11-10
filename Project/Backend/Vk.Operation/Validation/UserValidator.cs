using FluentValidation;
using Vk.Schema;

namespace Vk.Operation.Validation;

public class CreateUserValidator : AbstractValidator<UserRequest>
{
    public CreateUserValidator()
    {

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required.")
            .MinimumLength(1).WithMessage("UserName length min value is 1.");

        RuleFor(x => x.UserEmail)
            .NotEmpty().WithMessage("UserEmail is required.")
            .MinimumLength(1).WithMessage("UserEmail length min value is 1.");

        RuleFor(x => x.UserPassword)
            .NotEmpty().WithMessage("UserPassword is required.")
            .MinimumLength(1).WithMessage("UserPassword length min value is 1.");

        RuleFor(x => x.UserRole)
            .NotEmpty().WithMessage("UserRole is required.")
            .MaximumLength(10).WithMessage("UserRole cannot exceed 10 characters.")
            .Must(x => x == "Admin" || x == "Dealer")
            .WithMessage("UserRole must be 'Admin' or 'Dealer'.")
            .MinimumLength(1).WithMessage("UserRole length min value is 1.");

        RuleFor(x => x.UserBalance)
            .NotEmpty().WithMessage("UserBalance is required.");

        RuleFor(x => x.UserNumber)
            .NotEmpty().WithMessage("UserNumber is required.")
            .Must(x => x >= 10001 && x <= 999999).WithMessage("UserNumber must be a 6-digit number.");

    }
}
