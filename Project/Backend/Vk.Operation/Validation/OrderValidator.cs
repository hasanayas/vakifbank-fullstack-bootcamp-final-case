using FluentValidation;
using Vk.Schema;

namespace Vk.Operation.Validation;

public class CreateOrderValidator : AbstractValidator<OrderRequest>
{
    public CreateOrderValidator()
    {

        RuleFor(x => x.OrderStatus)
            .NotEmpty().WithMessage("OrderStatus is required.")
            .Must(x => x == "Waiting" || x == "Completed")
            .WithMessage("OrderStatus must be 'Waiting'  or 'Completed'.")
            .MinimumLength(1).WithMessage("OrderStatus length min value is 1.");

        RuleFor(x => x.OrderPaymentMethod)
            .NotEmpty().WithMessage("OrderPaymentMethod is required.")
            .MinimumLength(1).WithMessage("OrderPaymentMethod length min value is 1.")
            .Must(x => x == "EFT" || x == "Money Transfer" || x == "Credit Card" )
            .WithMessage("OrderStatus must be 'EFT', 'Money Transfer'or 'Credit Card'. ");

        RuleFor(x => x.OrderAmount)
            .NotEmpty().WithMessage("OrderAmount is required.")
            .GreaterThan(0).WithMessage("OrderAmount must be greater than 0.");   
    }
}
