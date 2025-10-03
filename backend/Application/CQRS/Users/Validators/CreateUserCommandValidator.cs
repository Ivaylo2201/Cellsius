using Application.CQRS.Users.Commands;
using FluentValidation;

namespace Application.CQRS.Users.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.Dto.Username)
            .NotEmpty().WithMessage("Username must be provided.")
            .Length(5, 25).WithMessage("Username must be between 5 and 25 characters.");
        
        RuleFor(c => c.Dto.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber must be provided.")
            .Length(10).WithMessage("PhoneNumber must be 10 characters long.");
        
        RuleFor(c => c.Dto.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(5).WithMessage("Password must be at least 5 characters long.")
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d).+$").WithMessage("Password must contain both letters and numbers.")
            .Must((c, password) => !password.Contains(c.Dto.Username)).WithMessage("Password must not contain username.");
        
        RuleFor(c => c.Dto.PasswordConfirmation)
            .NotEmpty().WithMessage("PasswordConfirmation must be provided.")
            .Equal(c => c.Dto.Password).WithMessage("Passwords do not match.");
    }
}