using Application.DTOs.User;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Users.Commands;

public record UpdateUserCommand(UpdateUserDto Dto) : IRequest<Unit>;