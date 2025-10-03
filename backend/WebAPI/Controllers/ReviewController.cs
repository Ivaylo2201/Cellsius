using Application.CQRS.Reviews.Commands;
using Application.DTOs.Review;
using Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddReviewAsync([FromBody] CreateReviewRequest request)
    {
        var createReviewDto = new CreateReviewDto
        {
            Rating = request.Rating,
            Comment = request.Comment,
            ProductId = request.ProductId,
            UserId = User.GetId()
        };
        
        await mediator.Send(new CreateReviewCommand(createReviewDto));
        return Created(string.Empty, new { message = "Review added successfully." });
    }
}