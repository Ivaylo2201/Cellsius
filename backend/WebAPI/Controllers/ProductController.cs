using Application.CQRS.Categories.Queries;
using Application.CQRS.Products.Queries;
using Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet("{category}")]
    public async Task<IActionResult> ListAllProductsByCategoryAsync([FromRoute] string category)
    {
        var categoryResult = await mediator.Send(new ListCategoriesQuery());
        var categoryNames = categoryResult.Value.Select(c => c.CategoryName.ToLower()).ToHashSet();
        
        if (!categoryNames.Contains(category.ToLower()))
            return NotFound(new { message = "Category not found." });
        
        var productsResult = await mediator.Send(new ListProductsQuery(category));
        var response = productsResult.Value.Select(p => p.ToShortDto()).ToList();
        
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] Guid id)
    {
        var productResult = await mediator.Send(new GetProductQuery(id));

        if (!productResult.IsSuccess)
            return NotFound(productResult.ErrorObject);
        
        var response = productResult.Value.ToLongDto();
        return Ok(response);
    }
}