using Application.CQRS.Users.Commands;
using Application.DTOs.User;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IMediator mediator, ITokenService tokenService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUpAsync([FromBody] CreateUserRequest request)
    {
        var createUserDto = new CreateUserDto
        {
            Username = request.Username,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            PasswordConfirmation = request.PasswordConfirmation
        };
        
        var createUserResult = await mediator.Send(new CreateUserCommand(createUserDto));
        
        if (!createUserResult.IsSuccess)
            return BadRequest(createUserResult.ErrorObject);

        var token = tokenService.GenerateToken(createUserResult.Value);
        return Created(string.Empty, new { token  });
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInUserRequest request)
    {
        var signInUserDto = new SignInUserDto
        {
            Username = request.Username,
            Password = request.Password,
        };
        
        var signInUserResult = await mediator.Send(new SignInUserCommand(signInUserDto));

        if (!signInUserResult.IsSuccess)
            return BadRequest(signInUserResult.ErrorObject);
        
        var token = tokenService.GenerateToken(signInUserResult.Value);
        return Created(string.Empty, new { token });
    }
}