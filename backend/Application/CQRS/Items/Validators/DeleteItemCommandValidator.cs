using Application.CQRS.Items.Commands;
using FluentValidation;

namespace Application.CQRS.Items.Validators;

public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
{
    public DeleteItemCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id must be provided.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}