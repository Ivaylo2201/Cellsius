using Application.CQRS.Items.Commands;
using FluentValidation;

namespace Application.CQRS.Items.Validators;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(c => c.Dto.Item)
            .NotEmpty().WithMessage("Item must be provided.");
        
        RuleFor(c => c.Dto.Quantity)
            .NotEmpty().WithMessage("Quantity must be provided.")
            .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");
    }
}