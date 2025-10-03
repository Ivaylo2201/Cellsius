using Application.CQRS.Items.Commands;
using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Interfaces.Services;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController(IMediator mediator, IOwnershipService ownershipService) : ControllerBase
{
    [Authorize]
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateItemQuantityAsync([FromRoute] int id, [FromBody] UpdateItemRequest request)
    {
        var itemResult = await mediator.Send(new GetItemQuery(id));

        if (!itemResult.IsSuccess)
            return NotFound(itemResult.ErrorObject);

        if (!await ownershipService.HasItemOwnershipAsync(itemResult.Value.CartId, User.GetId()))
            return Forbid();

        var updateItemDto = new UpdateItemDto
        {
            Item = itemResult.Value,
            Quantity = request.Quantity
        };
        
        await mediator.Send(new UpdateItemCommand(updateItemDto));
        
        return Ok(new { message = "Item quantity successfully updated." });
    }
}