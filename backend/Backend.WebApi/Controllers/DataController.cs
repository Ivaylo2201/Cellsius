using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController(IMediator mediator) : ControllerBase
{
    [HttpGet("colors")]
    public async Task<IActionResult> GetColorsAsync()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("shippings")]
    public async Task<IActionResult> GetShippingsAsync()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("brands")]
    public async Task<IActionResult> GetBrandsAsync()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("models")]
    public async Task<IActionResult> GetModelsAsync([FromQuery] string brand)
    {
        throw new NotImplementedException();
    }
}