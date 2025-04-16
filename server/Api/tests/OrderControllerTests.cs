using Api.Controllers;
using Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Xunit;
using Api.Data_Transfer_Objects;
using Api;

public class OrderControllerTests
{
    private readonly DatabaseContext _dbContext;
    private readonly OrderController _controller;
    private readonly int _userId = 1;

    public OrderControllerTests()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new DatabaseContext(options);

        var user = new User
        {
            Id = _userId,
            Email = "test@example.com",
            Username = "testuser",
            Password = "testpassword",
            Cart = new Cart
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Quantity = 2,
                        Phone = new Phone
                        {
                            Price = 500,
                            Brand = new Brand { Name = "BrandX" },
                            Model = new Model { Name = "ModelY" },
                            Color = new Color { Name = "Black" },
                            Memory = 32,
                            InitialPrice = 500,
                            ImagePath = "/"
                        }
                    }
                }
            }
        };

        var shipping = new Shipping
        {
            Id = 1,
            Type = "Standard",
            Cost = 20,
            Days = 5
        };

        _dbContext.Users.Add(user);
        _dbContext.Shippings.Add(shipping);
        _dbContext.SaveChanges();

        var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, _userId.ToString())
        }, "mock"));

        _controller = new OrderController(_dbContext);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = userClaims }
        };
    }

    [Fact]
    public void GetOrders_ReturnsOk_WhenValidUser()
    {
        var order = new Order
        {
            User = _dbContext.Users.First(),
            CreatedAt = DateTime.Now,
            Shipping = _dbContext.Shippings.First(),
            Items = _dbContext.Users.First().Cart!.Items.ToList(),
            Total = 1000
        };

        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();

        var result = _controller.GetOrders();

        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public void CreateOrder_ReturnsCreated_WhenCartIsValid()
    {
        var request = new CreateOrderRequest
        {
            ShippingId = 1
        };

        var result = _controller.CreateOrder(request);

        var created = result as CreatedAtActionResult;
        created.Should().NotBeNull();
        created!.Value.Should().BeEquivalentTo(new
        {
            message = "Order successfully placed!"
        });
    }
}
