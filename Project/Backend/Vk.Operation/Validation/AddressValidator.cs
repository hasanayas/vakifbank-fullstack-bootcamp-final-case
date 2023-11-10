using FluentValidation;
using Vk.Schema;

namespace Vk.Operation.Validation;

public class CreateAddressValidator : AbstractValidator<AddressRequest>
{
    public CreateAddressValidator()
    {

        RuleFor(x => x.AddressLine1)
            .NotEmpty().WithMessage("AddressLine1 is required.")
            .MinimumLength(1).WithMessage("AddressLine1 length min value is 1.");

        RuleFor(x => x.AddressLine2)
            .MaximumLength(100).WithMessage("AddressLine2 cannot exceed 100 characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MinimumLength(1).WithMessage("City length min value is 1.");

        RuleFor(x => x.County)
            .MaximumLength(50).WithMessage("County cannot exceed 50 characters.")
            .MinimumLength(1).WithMessage("County length min value is 1.");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required.");
    }
}

