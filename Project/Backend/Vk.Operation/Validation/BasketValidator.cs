using FluentValidation;
using Vk.Schema;

namespace Vk.Operation.Validation;

public class CreateBasketValidator : AbstractValidator<BasketRequest>
{
    public CreateBasketValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required.");

        RuleFor(x => x.BasketQuantity)
            .NotEmpty()
            .WithMessage("Basket quantity is required.");

        RuleFor(x => x.BasketPrice)
            .NotEmpty()
            .WithMessage("Basket price is required.");

        RuleFor(x => x.BasketStatus)
            .NotEmpty()
            .WithMessage("Basket status is required.");
    }
}

