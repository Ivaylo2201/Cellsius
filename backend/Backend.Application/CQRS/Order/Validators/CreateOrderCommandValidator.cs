using Backend.Application.CQRS.Order.Commands;
using FluentValidation;

namespace Backend.Application.CQRS.Order.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        
    }
}