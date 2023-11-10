using FluentValidation;
using Vk.Schema;

namespace Vk.Operation.Validation;

public class CreateProductValidator : AbstractValidator<ProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .MinimumLength(1).WithMessage("ProductName length min value is 1.");

        RuleFor(x => x.ProductImage)
            .NotEmpty().WithMessage("ProductImage is required.")
            .MinimumLength(1).WithMessage("ProductImage length min value is 1.");

        RuleFor(x => x.ProductQuantity)
            .NotEmpty()
            .WithMessage("Product quantity is required.");

        RuleFor(x => x.ProductPrice)
            .NotEmpty()
            .WithMessage("Product price is required.");

        RuleFor(x => x.ProductInformation)
            .NotEmpty()
            .WithMessage("Product information is required.")
            .MinimumLength(1).WithMessage("ProductInformation length min value is 1.");



    }
}
