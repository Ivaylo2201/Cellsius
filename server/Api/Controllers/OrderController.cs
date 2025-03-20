using Api.Data_Transfer_Objects;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(DatabaseContext context) : ControllerBase
    {
        private readonly DatabaseContext _context = context;

        [HttpGet]
        [Authorize]
        public IActionResult GetOrders()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                var orders = _context.Orders.Where(o => o.UserId == userId);
                return Ok(orders.Select(o => new
                {
                    id = o.Id,
                    total = o.Total,
                    items = o.Items,
                    createdAt = o.CreatedAt
                }));
            }
            else
            {
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpPost("place")]
        [Authorize]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                var user = _context.Users.Include(u => u.Cart).ThenInclude(c => c!.Items).Where(u => u.Id == userId).FirstOrDefault()!;

                if (user.Cart!.Items.Count() == 0)
                {
                    return BadRequest(new { message = "Cart is empty." });
                }

                var order = new Order { User = user, Items = user.Cart!.Items.Count(), Total = request.Total };

                _context.Orders.Add(order);
                _context.Items.RemoveRange(user.Cart.Items);

                _context.SaveChanges();

                return CreatedAtAction(nameof(CreateOrder), new { message = "Order successfully placed!" });
            }
            else
            {
                return BadRequest(new { message = "Something went wrong." });
            }
        }
    }
}
