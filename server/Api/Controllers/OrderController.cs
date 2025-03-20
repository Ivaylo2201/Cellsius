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
                var orders = _context.Orders.Include(c => c.Items)
                                                .ThenInclude(i => i.Phone)
                                                .ThenInclude(p => p.Brand)
                                            .Include(c => c.Items)
                                                .ThenInclude(i => i.Phone)
                                                .ThenInclude(p => p.Model)
                                            .Include(c => c.Items)
                                                .ThenInclude(i => i.Phone)
                                                .ThenInclude(p => p.Color)
                                            .Where(o => o.UserId == userId);

                return Ok(orders.Select(o => new
                {
                    id = o.Id,
                    total = o.Total,
                    items = o.Items.Select(i => new
                    {
                        i.Quantity,
                        Phone = new
                        {
                            brand = i.Phone.Brand.Name,
                            model = i.Phone.Model.Name,
                            color = i.Phone.Color.Name,
                            imagePath = i.Phone.ImagePath
                        },
                    }),
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

                var order = new Order { User = user, Total = request.Total };
                _context.Orders.Add(order);

                user.Cart!.Items.ForEach((item) =>
                {
                    item.Order = order;
                    item.IsOrdered = true;
                });

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
