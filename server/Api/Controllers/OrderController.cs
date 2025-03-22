using Api.Data_Transfer_Objects;
using Api.enums;
using Api.Models;
using Api.Services;
using Api.utils;
using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
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
            int? userId = AuthService.DecodeIdFromToken(User.FindFirst(ClaimTypes.NameIdentifier));

            if (userId is null)
            {
                return Unauthorized(ErrorMessage.GetMessageObject(ErrorType.InvalidToken));
            }

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

            return Ok(orders.Select(o => GetOrderData(o)));
        }

        [HttpPost("place")]
        [Authorize]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            int? userId = AuthService.DecodeIdFromToken(User.FindFirst(ClaimTypes.NameIdentifier));

            if (userId is null)
            {
                return Unauthorized(ErrorMessage.GetMessageObject(ErrorType.InvalidToken));
            }

            var user = _context.Users.Include(u => u.Cart!)
                                         .ThenInclude(c => c.Items)
                                         .ThenInclude(i => i.Phone)
                                     .Where(u => u.Id == userId)
                                     .Single();

            var shipping = _context.Shippings.Where(s => s.Id == request.ShippingId)
                                             .Single();

            if (user is null || shipping is null)
            {
                return NotFound(ErrorMessage.GetMessageObject(ErrorType.NotFound));
            }

            if (user.Cart!.Items.Count == 0)
            {
                return BadRequest(new { message = "Cart is empty." });
            }

            var order = new Order
            {
                User = user,
                Shipping = shipping,
                Total = user.Cart.Items.Sum(i => i.Quantity * i.Phone.Price) + shipping.Cost
            };

            _context.Orders.Add(order);

            user.Cart.Items.ToList().ForEach((i) =>
            {
                i.Order = order;
                i.Cart = null;
            });

            _context.SaveChanges();
            _ = SendOrderConfirmationEmail(user.Email, order.Id);

            return CreatedAtAction(
                nameof(CreateOrder),
                new { 
                    message = "Order successfully placed!"
                }
            );            
        }

        private static object GetItemData(Item i)
        {
            return new
            {
                i.Id,
                i.Quantity,
                Phone = new
                {
                    brand = i.Phone.Brand.Name,
                    model = i.Phone.Model.Name,
                    imagePath = i.Phone.ImagePath,
                },
                price = i.Quantity * i.Phone.Price
            };
        }

        private static object GetOrderData(Order o)
        {
            return new
            {
                o.Id,
                o.Total,
                items = o.Items.Select(i => GetItemData(i)),
                o.CreatedAt,
                shipping = new
                {
                    o.Shipping.Type,
                    o.Shipping.Cost,
                    o.Shipping.Days
                }
            };
        }

        private async Task SendOrderConfirmationEmail(string email, int orderId)
        {
            var order = _context.Orders.Include(o => o.Items)
                                            .ThenInclude(i => i.Phone)
                                            .ThenInclude(p => p.Brand)
                                        .Include(o => o.Items)
                                            .ThenInclude(i => i.Phone)
                                            .ThenInclude(p => p.Model)
                                        .Include(o => o.Items)
                                            .ThenInclude(i => i.Phone)
                                            .ThenInclude(p => p.Color)
                                        .Include(o => o.Shipping)
                                        .Where(o => o.Id == orderId)
                                        .Single();

            string subject = $"Order #{order.Id} Confirmation";
            string body = new ReceiptService(order).GetReceipt();

            await EmailService.SendEmailAsync(email, subject, body);
        }
    }
}
