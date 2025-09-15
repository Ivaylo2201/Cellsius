using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController(IMediator mediator) : ControllerBase
{
    [HttpPatch("{id:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateItemQuantity([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetItemsInCart()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddItemToCart([FromBody] object request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> RemoveItemFromCart([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
}