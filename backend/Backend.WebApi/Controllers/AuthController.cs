using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] object request)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] object request)
    {
        throw new NotImplementedException();
    }
}