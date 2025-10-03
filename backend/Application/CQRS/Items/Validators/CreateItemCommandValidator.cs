using Application.CQRS.Items.Commands;
using FluentValidation;

namespace Application.CQRS.Items.Validators;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(c => c.Dto.Product)
            .NotEmpty().WithMessage("Product must be provided.");
        
        RuleFor(c => c.Dto.Quantity)
            .GreaterThanOrEqualTo(1).WithMessage("Quantity must be greater than or equal to 1.");

        RuleFor(c => c.Dto.Cart)
            .NotEmpty().WithMessage("Cart must be provided.");
    }
}