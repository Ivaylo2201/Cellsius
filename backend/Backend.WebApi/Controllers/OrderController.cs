using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetOrdersForUserAsync()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateOrderAsync([FromBody] object request)
    {
        throw new NotImplementedException();
    }
}