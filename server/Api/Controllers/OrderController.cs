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

        private IEnumerable<Item> getUnorderedItems(User user)
        {
            return user.Cart!.Items.Where(i => i.IsOrdered == false);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetOrders()
        {

            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                var orders = _context.Orders.Include(o => o.Items)
                                                .ThenInclude(i => i.Phone)
                                                .ThenInclude(p => p.Brand)
                                            .Include(o => o.Items)
                                                .ThenInclude(i => i.Phone)
                                                .ThenInclude(p => p.Model)
                                            .Include(o => o.Items)
                                                .ThenInclude(i => i.Phone)
                                                .ThenInclude(p => p.Color)
                                            .Include(o => o.Shipping)
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
                            imagePath = i.Phone.ImagePath,
                        },
                        price = i.Quantity * i.Phone.Price
                    }),
                    createdAt = o.CreatedAt,
                    shipping = o.Shipping
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
                var user = _context.Users.Include(u => u.Cart)
                                         .ThenInclude(c => c!.Items)
                                         .ThenInclude(i => i.Phone)
                                         .Where(u => u.Id == userId)
                                         .FirstOrDefault()!;

                var shipping = _context.Shippings.Where(s => s.Id == request.ShippingId).FirstOrDefault()!;

                if (user.Cart!.Items.Count() == 0)
                {
                    return BadRequest(new { message = "Cart is empty." });
                }

                var order = new Order { 
                    User = user,
                    Shipping = shipping,
                    Total = this.getUnorderedItems(user).Sum(i => i.Quantity * i.Phone.Price) + shipping.Cost
                };

                _context.Orders.Add(order);

                this.getUnorderedItems(user)
                    .ToList()
                    .ForEach((item) =>
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
