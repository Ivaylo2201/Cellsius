using Application.CQRS.Reviews.Commands;
using FluentValidation;

namespace Application.CQRS.Reviews.Validators;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(c => c.Dto.Rating)
            .NotEmpty().WithMessage("Rating must be provided.")
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
        
        RuleFor(c => c.Dto.Comment)
            .MaximumLength(255).WithMessage("Comment cannot be longer than 255 characters.");
        
        RuleFor(c => c.Dto.UserId)
            .NotEmpty().WithMessage("UserId must be provided.")
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        
        RuleFor(c => c.Dto.ProductId)
            .NotEqual(Guid.Empty).WithMessage("ProductId must be provided.");
    }
}