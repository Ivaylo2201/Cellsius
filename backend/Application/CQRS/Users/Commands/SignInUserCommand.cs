using Application.DTOs.User;
using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Users.Commands;

public record SignInUserCommand(SignInUserDto Dto) : IRequest<Result<User>>;