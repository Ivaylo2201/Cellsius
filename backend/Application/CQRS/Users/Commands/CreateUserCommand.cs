using Application.DTOs.User;
using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Users.Commands;

public record CreateUserCommand(CreateUserDto Dto) : IRequest<Result<User>>;