using Application.CQRS.Users.Commands;
using FluentValidation;

namespace Application.CQRS.Users.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.Dto.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber must be provided.")
            .Length(10).WithMessage("PhoneNumber must be 10 characters long.");

        RuleFor(c => c.Dto.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(5).WithMessage("Password must be at least 5 characters long.")
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d).+$").WithMessage("Password must contain both letters and numbers.");
    }
}